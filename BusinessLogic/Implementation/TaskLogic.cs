using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using TmTaskManagerApi.BusinessLogic.Structure;
using TmTaskManagerApi.Database.Implementation;
using TmTaskManagerApi.Database.Structure;
using TmTaskManagerApi.Models;

namespace TmTaskManagerApi.BusinessLogic.Implementation
{
    public class TaskLogic : ITaskLogic
    {
        private ITaskDataHandler? taskDataHandler;
        public TaskLogic()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection = serviceCollection.AddTransient<ITaskDataHandler, TaskDataHandler>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            taskDataHandler = serviceProvider.GetService<ITaskDataHandler>();
            if (taskDataHandler == null)
                taskDataHandler = new TaskDataHandler();
        }

        

        public async Task<List<Tasks>> GetAllTaskAsync()
        {
            List<Tasks> taskList = new List<Tasks>();
            try
            {
                taskList = await taskDataHandler.GetAllEntryAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return taskList;
        }

        public async Task<Tasks?> GetTaskAsync(int taskId)
        {
            Tasks? taskObj = new Tasks();
            try
            {
                taskObj = await taskDataHandler.GetSpecificEntryAsync(taskId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return taskObj;
        }

        public async Task<bool> AddTaskAsync(Tasks taskdata)
        {
            bool addResponse = false;
            try
            {
                taskdata.created_on = DateTime.Now;
                taskdata.created_date = DateTime.Now;
                taskdata.updated_on = DateTime.Now;
                addResponse = await taskDataHandler.AddEntryAsync(taskdata);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return addResponse;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            bool deleteResponse = false;
            try
            {
                deleteResponse = await taskDataHandler.DeleteEntryAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return deleteResponse;
        }
        public async Task<bool> UpdateTaskAsync(Tasks taskdata)
        {
            bool updateResponse = false;
            try
            {
                taskdata.updated_on = DateTime.Now;
                updateResponse = await taskDataHandler.UpdateEntryAsync(taskdata);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return updateResponse;
        }
    }
}
