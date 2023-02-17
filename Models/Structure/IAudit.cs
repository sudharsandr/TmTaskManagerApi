namespace TmTaskManagerApi.Models.Structure
{
    public interface IAudit
    {
        public DateTime created_on { get; set; }

        public DateTime updated_on { get; set; }
    }
}
