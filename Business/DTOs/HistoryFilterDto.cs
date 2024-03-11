using Data.Models;

namespace Business.DTOs
{
    public class HistoryFilterDto
    {
        public LogicType LogicType { get; set; } = LogicType.Propositional;
        public Guid? UserId { get; set; }
    }
}
