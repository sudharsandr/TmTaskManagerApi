using TmTaskManagerApi.Models;

namespace TmTaskManagerApi.Database.Structure
{
    public interface ITaskDataHandler: ICrudHandler<Tasks>
    {
        //public Task<List<Tasks>> GetAllTaskAsync();

        //public Task<Tasks?> GetTaskAsync(int id);

        //public Task<bool> AddTaskAsync(Tasks taskdata);

        //public Task<bool> UpdateTaskAsync(Tasks taskdata);

        //public Task<bool> DeleteTaskAsync(int id);
    }
}
