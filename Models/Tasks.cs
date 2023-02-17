using System.Numerics;

namespace TmTaskManagerApi.Models
{
    public class Tasks : CommonAttributes
    {
        public string? title { get; set; }

        public string? description { get; set; }

        public int task_type { get; set; }

        public int status_id { get; set; }

        public int assigned_to { get; set; }

        public DateTime created_date { get; set; }

        public DateTime required_date { get; set; }

        

    }
}
