namespace TmTaskManagerApi.Models
{
    public class Comment: CommonAttributes
    {
        public int task_id { get; set; }

        public int comment_history_id { get; set; }

        public CommentHistory? comment_data { get; set; }
    }
}
