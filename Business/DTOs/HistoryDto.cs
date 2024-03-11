using Data.Models;

namespace Business.DTOs
{
    public class HistoryDto
    {
        public DateTime Created { get; set; }
        public Guid? UserId { get; set; }

        public LogicType LogicType { get; set; }

        public Guid FormulaId { get; set; }

        public virtual Formula Formula { get; set; }

        public HistoryDto(History history)
        {
            UserId = history.UserId;
            LogicType = history.LogicType;
            FormulaId = history.FormulaId;
            Formula = history.Formula;
            Created = history.Created;
        }

        public string GetLogicTypeString()
        {
            switch (LogicType)
            {
                case LogicType.Propositional:
                    return "Výroková";
                case LogicType.Predicate:
                    return "Predikátová";
            }
            return string.Empty;
        }

        public string GetFormulaTypeString()
        {
            if(Formula.FormulaType == FormulaType.Basic)
            {
                return "Jednoduchá";
            }

            return "Klauzula";
        }
    }
}