using Data.Models;
using Newtonsoft.Json;

namespace Business.DTOs.Formulas
{
    public class ResultDto
    {
        public TruthTableRepresentation Table { get; set; } = new();
        public ClausuleCNFDto Clausule { get; set; } = new();
        public List<(ClausuleCNFFormula, ClausuleCNFFormula)> Resolution { get; set; } = new();
        public List<SimplisticFormulaInDb> Formulas { get; set; } = new();
        public Formula Formula { get; private set; }

        public ResultDto()
        {            
        }

        public ResultDto(Formula formula)
        {
            Formula = formula;
            Table = Table.Parse(formula.TruthTable ?? string.Empty);
            Clausule = Clausule.Parse(formula.Clausule ?? string.Empty);
            Resolution = JsonConvert.DeserializeObject<List<(ClausuleCNFFormula, ClausuleCNFFormula)>>(formula.Resolution ?? string.Empty) ?? new();
            if(formula.FormulaType == FormulaType.Clausule)
            {
                Formulas = JsonConvert.DeserializeObject<List<SimplisticFormulaInDb>>(formula.Formulas) ?? new();
            }
        }
    }

    public class SimplisticFormulaInDb
    {
        public Guid Id { get; set; }
        public string Input { get; set; } = string.Empty;
    }

    public class TruthTableRepresentation
    {
        public List<List<string>> Table { get; set; } = new List<List<string>>();

        public bool IsEmpty => Table.Count == 0;

        public TruthTableRepresentation Parse(string table)
        {
            var t = JsonConvert.DeserializeObject<List<List<string>>>(table);
            return new TruthTableRepresentation() { Table = t ?? new() };
        }
    }
}
