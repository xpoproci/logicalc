namespace Business.DTOs
{
    public class FeedbackDto
    {
        public string Improvement { get; set; } = string.Empty;

        public string Bug { get; set; } = string.Empty;

        public List<QuestionDto> Questions { get; set; } = new();
    }

    public class QuestionDto
    {
        public Guid Id { get; set; } = Guid.Empty;
        public int Value { get; set; } = 0;
        public string Text { get; set; } = string.Empty;
    }
}
