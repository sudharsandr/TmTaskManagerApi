using TmTaskManagerApi.Models;

namespace TmTaskManagerApi.BusinessLogic.Structure
{
    public interface ITaskLogic
    {
        public Task<List<Tasks>> GetAllTaskAsync();

        public Task<Tasks?> GetTaskAsync(int taskId);

        public Task<bool> AddTaskAsync(Tasks taskdata);

        public Task<bool> UpdateTaskAsync(Tasks taskdata);

        public Task<bool> DeleteTaskAsync(int id);
    }
}
