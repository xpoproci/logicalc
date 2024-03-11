namespace Data.Models
{
    public class Feedback : BaseEntity
    {
        public string Questions { get; set; } = string.Empty;

        public string Improvement { get; set; } = string.Empty;

        public string Bug { get; set; } = string.Empty;
    }
}
