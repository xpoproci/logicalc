using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class History : BaseEntity
    {
        public Guid? UserId { get; set; }
        
        public LogicType LogicType { get; set; }

        [Required]
        public Guid FormulaId { get; set; }

        [ForeignKey(nameof(FormulaId))]
        public virtual Formula Formula { get; set; }
    }
}
