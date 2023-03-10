using Dapper;
using Npgsql;
using System.Threading.Tasks;
using TmTaskManagerApi.Database.Structure;
using TmTaskManagerApi.Models;

namespace TmTaskManagerApi.Database.Implementation
{
    public class TaskDataHandler : ITaskDataHandler
    {
        private string connectionStr = String.Empty;

        public TaskDataHandler()
        { 
            connectionStr = DatabaseConstants.DbConnectionStr;
        }

        
        public async Task<List<Tasks>> GetAllEntryAsync()
        {
            List<Tasks> taskList = new List<Tasks>();
            try
            {
                using (var dbConnection = new NpgsqlConnection(this.connectionStr))
                {
                    dbConnection.Open();
                    var queryResult = await dbConnection.QueryAsync<Tasks>(DatabaseConstants.AllTask);
                    taskList = queryResult.ToList();
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return taskList;
        }

        public async Task<Tasks?> GetSpecificEntryAsync(int id)
        {
            Tasks ?taskObj = new Tasks();
            try
            {
                using (var dbConnection = new NpgsqlConnection(this.connectionStr))
                {
                    dbConnection.Open();
                    var query = string.Format(DatabaseConstants.SpecificTask, id.ToString());
                    var queryResult = await dbConnection.QueryAsync<Tasks>(query);
                    taskObj = queryResult.FirstOrDefault();
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return taskObj;
        }

        public async Task<bool> AddEntryAsync(Tasks taskdata)
        {
            object queryResult;
            try
            {
                using (var dbConnection = new NpgsqlConnection(this.connectionStr))
                {
                    dbConnection.Open();
                    var query = string.Format(DatabaseConstants.AddTask, 
                        taskdata.title, 
                        taskdata.description, 
                        taskdata.task_type, 
                        taskdata.status_id,
                        taskdata.assigned_to,
                        taskdata.created_date,
                        taskdata.required_date,
                        taskdata.created_on,
                        taskdata.updated_on);
                    queryResult = await dbConnection.QueryAsync<object>(query);
                    
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateEntryAsync(Tasks taskdata)
        {

            object queryResult;
            try
            {
                using (var dbConnection = new NpgsqlConnection(this.connectionStr))
                {
                    dbConnection.Open();
                    var query = string.Format(DatabaseConstants.UpdateTask,
                        taskdata.title,
                        taskdata.description,
                        taskdata.task_type,
                        taskdata.status_id,
                        taskdata.assigned_to,
                        taskdata.required_date,
                        taskdata.updated_on,
                        taskdata.id);
                    queryResult = await dbConnection.QueryAsync<object>(query);

                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            return true;
        }

       

        public async Task<bool> DeleteEntryAsync(int id)
        {
            object queryResult;
            try
            {
                using (var dbConnection = new NpgsqlConnection(this.connectionStr))
                {
                    dbConnection.Open();
                    var currentTime = DateTime.Now.ToString();
                    var query = string.Format(DatabaseConstants.DeleteTask, currentTime,  id);
                    queryResult = await dbConnection.QueryAsync<object>(query);

                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            return true;
        }

    }
}
