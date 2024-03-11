namespace Data.Models
{
    public class Question : BaseEntity
    {
        public string Text { get; set; } = string.Empty;
        public int Order { get; set; } = 0;
    }
}
