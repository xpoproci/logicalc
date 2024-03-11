using Business.DTOs.Formulas;
using Business.ParserModels;
using Business.ParserModels.Nodes;

namespace Business.Functions
{
    public class TruthTable
    {
        private readonly WellFormedFormula _tree;

        private readonly List<List<string>> _table = new();

        private ClausuleCNFDto _clausuleCNF = new();

        private ClausuleDNFDto _clausuleDNF = new();

        public bool Tautology { get; private set; } = true;

        public bool Contradiction { get; private set; } = true;

        public bool Solvable => !Contradiction;

        public TruthTable(WellFormedFormula tree)
        {
            _tree = tree;
        }

        public void GenerateTruthTable()
        {
            CreateTable();
        }

        public List<List<string>> GetTable()
        {
            return _table;
        }

        private void CreateTable()
        {
            //get all atoms
            var atoms = _tree.GetAtoms();

            //group atoms with same symbol
            var groupedAtoms = GroupAtomNodes(atoms);

            //create first row of table
            _table.Add(new());
            foreach (var atom in groupedAtoms)
            {
                _table[0].Add(atom.Key);
            }
            //add final formula
            _table[0].Add(_tree.GetStringRep());

            //add values
            DistributeTruthValues(groupedAtoms);
        }

        private Dictionary<string, List<AtomNode>> GroupAtomNodes(List<AtomNode> atoms)
        {
            var result = new Dictionary<string, List<AtomNode>>();
            foreach (var atom in atoms)
            {
                if (atom.Symbol == null) continue;
                if (!result.ContainsKey(atom.Symbol))
                {
                    result.Add(atom.Symbol, new List<AtomNode>());
                }
                result[atom.Symbol].Add(atom);
            }

            return result;
        }

        private void DistributeTruthValues(Dictionary<string, List<AtomNode>> groupedAtoms)
        {
            // The total number of combinations is 2^n, where n is the number of atoms
            int totalCombinations = (int)Math.Pow(2, groupedAtoms.Count);

            for (int i = 0; i < totalCombinations; i++)
            {
                //add new row to table
                _table.Add(new());
                var row = _table.Count - 1;
                var clausuleCNFFormula = new ClausuleCNFFormula();
                var clausuleDNFFormula = new ClausuleDNFFormula();
                for (var j = 0; j < groupedAtoms.Count; j++)
                {
                    // Create a new AtomNode with the same symbol as the original,
                    // but with a truth value determined by the j-th bit of i
                    bool truthValue = ((i >> j) & 1) == 1;
                    var atoms = groupedAtoms.ElementAt(j);
                    atoms.Value.ForEach(x => { 
                        x.SetTruthValue(truthValue);
                        var exclamationMark = truthValue ? "" : "¬";
                        var literal = new ClausuleLiteral()
                        {
                            Representation = $"{exclamationMark}{x.Symbol ?? "Default"}"
                        };

                        clausuleCNFFormula.Literals.Add(literal);
                        clausuleDNFFormula.Literals.Add(literal);
                    });
                    _table[row].Add(atoms.Value.First().GetTruthValue());
                }

                var result = _tree.Evaluate();
                DecideTautologyAndContradiction(result);

                //add clausule if the result is 0
                if (!result)
                {
                    _clausuleCNF.Clausules.Add(clausuleCNFFormula);
                }
                else
                {
                    _clausuleDNF.Clausules.Add(clausuleDNFFormula);
                }

                _table[row].Add(result ? "1" : "0");
            }
        }

        private void DecideTautologyAndContradiction(bool eval)
        {
            Tautology = Tautology && eval;
            Contradiction = Contradiction && !eval;
        }

        public bool IsEquivalentFormula(WellFormedFormula other)
        {
            var a1 = _tree.GetAtoms();
            var a2 = other.GetAtoms();

            a1.Sort();
            a2.Sort();

            //compare atoms first
            var h1 = new HashSet<AtomNode>(a1);
            var h2 = new HashSet<AtomNode>(a2);
            if (!h1.SetEquals(h2))
            {
                return false;
            }

            var ga1 = GroupAtomNodes(a1);
            var ga2 = GroupAtomNodes(a2);

            var result = true;

            int totalCombinations = (int)Math.Pow(2, ga1.Count);

            for (int i = 0; i < totalCombinations; i++)
            {
                var row = _table.Count - 1;

                for (var j = 0; j < ga1.Count; j++)
                {
                    // Create a new AtomNode with the same symbol as the original,
                    // but with a truth value determined by the j-th bit of i
                    bool truthValue = ((i >> j) & 1) == 1;
                    var atoms1 = ga1.ElementAt(j);
                    atoms1.Value.ForEach(x => x.SetTruthValue(truthValue));

                    var atoms2 = ga2.ElementAt(j);
                    atoms2.Value.ForEach(x => x.SetTruthValue(truthValue));
                }

                result = result && (_tree.Evaluate() == other.Evaluate());
            }

            return result;
        }

        public ClausuleCNFDto GetUCNFClausule(bool complete = false)
        {
            if (_tree.IsCNFClausule() && !complete)
            {
                _clausuleCNF = _tree.GetCNFClausule();
            }
            _clausuleCNF.FixLiteralsValues();
            return _clausuleCNF;
        }

        public ClausuleDNFDto GetUDNFClausule(bool complete = false)
        {
            return _clausuleDNF;
        }
    }
}
