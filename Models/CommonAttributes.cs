using TmTaskManagerApi.Models.Structure;

namespace TmTaskManagerApi.Models
{
    public class CommonAttributes: IPrimaryKey, IAudit
    {
        public int id { get; set; }
        public DateTime created_on { get; set; }

        public DateTime updated_on { get; set; }
    }
}
