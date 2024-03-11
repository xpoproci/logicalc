using Antlr4.Runtime.Tree;
using Business.DTOs;
using Business.DTOs.Formulas;
using Business.Functions;
using Business.Helpers;
using Business.Input;
using Business.ParserModels;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace Business.Facades
{
    public class FormulaFacade
    {
        private readonly LogicParserAdapter _adapter;
        private readonly LogicalcDbContext _context;

        private readonly Stopwatch _timer = new();
        private readonly Stopwatch _clausuleTimer = new();

        public FormulaFacade(LogicalcDbContext context)
        {
            _context = context;
            _adapter = new LogicParserAdapter();
        }

        public FormulaFacade()
        {
            _adapter = new LogicParserAdapter();
            _context = null;
        }

        public async Task<ResultDto> GetResultAsync(Guid id)
        {
            var r = await _context.Formulas.Where(f => f.Id == id).FirstOrDefaultAsync();
            if (r == null)
            {
                return new ResultDto();
            }

            return new ResultDto(r);
        }

        public async Task<List<HistoryDto>> GetHistoryAsync(HistoryFilterDto? filter)
        {
            var query = _context.History.AsNoTracking();
            if (filter != null) {
                query = query.Where(x => x.LogicType == filter.LogicType);
                if(filter.UserId != null)
                {
                    query = query.Where(x=>x.UserId == filter.UserId);
                }
            }

            var result = await query.Include(x=>x.Formula)
                .Select(x=> new HistoryDto(x))
                .ToListAsync();
            return result;
        }

        public async Task<Guid> CalculateClausule(List<string> inputs, LogicType type, UserDto? user)
        {
            _clausuleTimer.Start();
            var listFormulas = new List<SimplisticFormulaInDb>();
            var listWffs = new List<WellFormedFormula>();
            foreach (var input in inputs)
            {
                var trees = _adapter.GetAbstractSyntaxTree(input);
                if (!trees.Any())
                {
                    _clausuleTimer.Stop();
                    return Guid.Empty;
                }
                var first = trees.First();
                listWffs.Add(first);
                var id = await CalculateFormula(input, type, user);
                listFormulas.Add(new SimplisticFormulaInDb() { Id = id, Input = first.GetStringRep()});
            }

            var concatedInput = inputs.GetConcatedCNF();
            var treesConcated = _adapter.GetAbstractSyntaxTree(concatedInput);
            if (!treesConcated.Any())
            {
                _clausuleTimer.Stop();
                return Guid.Empty;
            }
            var tree = treesConcated.First();
            var strRep = tree.GetStringRep();

            var rF = await _context.Formulas.Where(x => x.Input.Equals(strRep) && x.FormulaType == FormulaType.Clausule).Select(x => x.Id).FirstOrDefaultAsync();
            if (rF != Guid.Empty)
            {
                _timer.Stop();
                return rF;
            }

            var concatedClausule = new ClausuleCNFDto();
            foreach (var wff in listWffs)
            {
                concatedClausule.ConcatClausule(wff.GetCNFClausule());
            }

            concatedClausule.FixLiteralsValues();

            var truthTable = new TruthTable(tree);
            if (type == LogicType.Propositional)
            {
                truthTable.GenerateTruthTable();
            }

            var tt = truthTable.GetTable();
            var cnf = truthTable.GetUCNFClausule(true);
            var dnf = truthTable.GetUDNFClausule();

            //to get resolution we need to negate input formula
            var clausuleString = JsonConvert.SerializeObject(concatedClausule);
            var resolution = ResolveClausule(concatedClausule);

            _clausuleTimer.Stop();

            var ttString = JsonConvert.SerializeObject(tt);
            var resolutionString = JsonConvert.SerializeObject(resolution);

            var f = new Formula()
            {
                CNF = strRep,
                UCNF = cnf.ToString(),
                UDNF = dnf.ToString(),
                TruthTable = ttString,
                Skolemization = string.Empty, //TODO:
                LogicType = type,
                Input = strRep,
                ComputationTime = _clausuleTimer.ElapsedMilliseconds.ToString(),
                Resolution = resolutionString,
                Tautology = truthTable.Tautology,
                Contradiction = truthTable.Contradiction,
                Satisfiability = truthTable.Solvable,
                FormulaType = FormulaType.Clausule,
                Clausule = clausuleString,
                Formulas = JsonConvert.SerializeObject(listFormulas)
            };

            await _context.AddAsync(f);

            var h = new History()
            {
                Formula = f,
                LogicType = type,
                UserId = user?.Id
            };

            await _context.AddAsync(h);

            await _context.SaveChangesAsync();

            return f.Id;
        }

        public async Task<Guid> CalculateFormula(string input, LogicType type, UserDto? user)
        {
            _timer.Start();
            var trees = _adapter.GetAbstractSyntaxTree(input);
            if (!trees.Any()) {
                _timer.Stop();
                return Guid.Empty;
            }

            var first = trees.First();
            //get from db if exists
            var strRep = first.GetStringRep();
            var rF = await _context.Formulas.Where(x => x.Input.Equals(strRep)).Select(x => x.Id).FirstOrDefaultAsync();
            if(rF != Guid.Empty)
            {
                _timer.Stop();
                return rF;
            }

            var truthTable = new TruthTable(first);
            if (type == LogicType.Propositional)
            {
                truthTable.GenerateTruthTable();
            }

            var tt = truthTable.GetTable();
            var cnf = truthTable.GetUCNFClausule(true);
            var dnf = truthTable.GetUDNFClausule();

            //to get resolution we need to negate input formula
            var resolution = GetNegatedResolution(input, type);

            _timer.Stop();

            var ttString = JsonConvert.SerializeObject(tt);
            var resolutionString = JsonConvert.SerializeObject(resolution.Item2);

            var f = new Formula()
            {
                UCNF = cnf.ToString(),
                UDNF = dnf.ToString(),
                TruthTable = ttString,
                Skolemization = string.Empty, //TODO:
                LogicType = type,
                Input = first.GetStringRep(),
                ComputationTime = _timer.ElapsedMilliseconds.ToString(),
                Resolution = resolutionString,
                Tautology = truthTable.Tautology,
                Contradiction = truthTable.Contradiction,
                Satisfiability = truthTable.Solvable,
                FormulaType = FormulaType.Basic,
                Clausule = resolution.Item1
            };

            await _context.AddAsync(f);

            var h = new History()
            {
                Formula = f,
                LogicType = type,
                UserId = user?.Id
            };

            await _context.AddAsync(h);

            await _context.SaveChangesAsync();

            return f.Id;
        }

        private (string, List<(ClausuleCNFFormula, ClausuleCNFFormula)>) GetNegatedResolution(string input, LogicType type)
        {
            var result = (string.Empty, new List<(ClausuleCNFFormula, ClausuleCNFFormula)>());
            input = $"!{input}"; //negate whole expression
            var trees = _adapter.GetAbstractSyntaxTree(input);
            if (!trees.Any())
            {
                return result;
            }
            var first = trees.First();

            var truthTable = new TruthTable(first);
            if (type == LogicType.Propositional)
            {
                truthTable.GenerateTruthTable();
            }

            var cnf = truthTable.GetUCNFClausule();
            result.Item1 = JsonConvert.SerializeObject(cnf);
            result.Item2 = ResolveClausule(cnf);

            return result;
        }

        //input and clausules
        public async Task<bool> ValidateInputAsync(string input, LogicType type = LogicType.Propositional, bool isClausule = false)
        {
            var result = true;
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            try
            {
                var tree = _adapter.GetAbstractSyntaxTree(input);
                if (!_adapter.IsValid)
                {
                    result = result && false;
                }

                foreach (var item in tree)
                {
                    if (!item.IsValid())
                    {
                        result = result && false;
                        break;
                    }

                    if (type == LogicType.Predicate)
                    {
                        if (!item.IsPredicateWff())
                        {
                            result = result && false;
                            break;
                        }

                    }
                    else if (type == LogicType.Propositional)
                    {
                        if (!item.IsPropositionalWff())
                        {
                            result = result && false;
                            break;
                        }
                    }

                    if (isClausule)
                    {
                        if (!item.IsCNFClausule())
                        {
                            result = result && false;
                            break;
                        }
                    }
                }
            }catch
            {
                result = false;
            }            

            return await Task.FromResult(result);
        }

        public List<(ClausuleCNFFormula, ClausuleCNFFormula)> ResolveClausule(ClausuleCNFDto clausule)
        {
            var result = new List<(ClausuleCNFFormula, ClausuleCNFFormula)>();
            if(!clausule.Clausules.Any() || clausule.Clausules.Count == 1) {
                clausule.Clausules.Clear();
                return result;
            }

            var clausulesCount = clausule.Clausules.Count;

            var limit = Math.Pow(2, clausulesCount);
            var iteration = 0;
            var innerIteration = 0;

            for (int i = 0; i < clausule.Clausules.Count; i++)
            {
                if(iteration >= limit)
                {
                    //get rid of memory
                    clausule.Clausules.Clear();
                    result.Clear();
                    return result;
                }
                innerIteration = 0;

                for (int j = i + 1; j < clausule.Clausules.Count; j++)
                {
                    var clause1 = clausule.Clausules.ElementAt(i);
                    var clause2 = clausule.Clausules.ElementAt(j);

                    var resolvent = ResolveClausuleFormulas(clause1, clause2);
                    resolvent.RemoveTautologicalLiterals();

                    result.Add((clause1, clause2));

                    if (!resolvent.Literals.Any())
                    {
                        clausule.Clausules.Clear();
                        return result;
                    }
                    clausule.Clausules.Add(resolvent);
                    innerIteration++;
                    if(innerIteration >= limit)
                    {
                        break;
                    }
                }
                iteration++;
            }
            
            return result;
        }
                
        public ClausuleCNFFormula ResolveClausuleFormulas(ClausuleCNFFormula formula, ClausuleCNFFormula formula2) { 
            var concated = new HashSet<ClausuleLiteral>();

            concated = formula.Literals.Concat(formula2.Literals).ToHashSet();

            var clausuleFormula = new ClausuleCNFFormula();
            var result = new HashSet<ClausuleLiteral>();

            foreach (var l in concated)
            {
                if (result.Select(x=>x.Value).Contains(-l.Value))
                {
                    var toRemove = result.Where(x => x.Value == -l.Value).First();
                    result.Remove(toRemove);
                }
                else
                {
                    result.Add(l);
                }
            }

            clausuleFormula.Literals = result;
            return clausuleFormula;
        }
    }
}
