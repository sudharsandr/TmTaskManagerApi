namespace TmTaskManagerApi.Models
{
    public class CommentHistory: CommonAttributes
    {
        public string? comment { get; set; }

        public int comment_type { get; set; }

        public DateTime reminder_date { get; set; }
    }
}
