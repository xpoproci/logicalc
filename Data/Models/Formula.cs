namespace Data.Models
{
    public class Formula : BaseEntity
    {
        public string Input { get; set; } = string.Empty;
        public string ComputationTime { get; set; } = string.Empty;
        public LogicType LogicType { get; set; } = LogicType.Propositional;
        public FormulaType FormulaType { get; set; } = FormulaType.Basic;
        public bool Tautology { get; set; } = false;
        public bool Contradiction { get; set; } = false;
        public bool Satisfiability { get; set; } = false;
        public string TruthTable { get; set; } = string.Empty;
        public string UDNF { get; set; } = string.Empty;
        public string UCNF { get; set; } = string.Empty;
        public string CNF { get; set; } = string.Empty;
        public string DNF { get; set; } = string.Empty;
        public string Skolemization { get; set; } = string.Empty;
        public string Prenex { get; set; } = string.Empty;

        /// <summary>
        /// if clausule, this contains IDs of formulas
        /// </summary>
        public string Formulas { get; set; } = string.Empty;
        public string Resolution { get; set; } = string.Empty;
        public string Clausule { get; set; } = string.Empty;
    }
}
