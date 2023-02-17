using Dapper;
using Npgsql;
using TmTaskManagerApi.Database.Structure;
using TmTaskManagerApi.Models;

namespace TmTaskManagerApi.Database.Implementation
{
    public class CommentDataHandler: ICommentDataHandler
    {
        private string connectionStr = String.Empty;

        public CommentDataHandler()
        {
            connectionStr = DatabaseConstants.DbConnectionStr;
        }


        public async Task<List<Comment>> GetAllEntryAsync()
        {
            List<Comment> taskList = new List<Comment>();
            try
            {
                using (var dbConnection = new NpgsqlConnection(this.connectionStr))
                {
                    dbConnection.Open();
                    var queryResult = await dbConnection.QueryAsync<Comment>(DatabaseConstants.AllComment);
                    taskList = queryResult.ToList();
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return taskList;
        }

        public async Task<Comment?> GetSpecificEntryAsync(int id)
        {
            Comment? taskObj = new Comment();
            try
            {
                using (var dbConnection = new NpgsqlConnection(this.connectionStr))
                {
                    dbConnection.Open();
                    var query = string.Format(DatabaseConstants.SpecificTask, id.ToString());
                    var queryResult = await dbConnection.QueryAsync<Comment>(query);
                    taskObj = queryResult.FirstOrDefault();
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return taskObj;
        }

        public async Task<bool> AddEntryAsync(Comment taskdata)
        {
            object queryResult;
            try
            {
                using (var dbConnection = new NpgsqlConnection(this.connectionStr))
                {
                    dbConnection.Open();
                    var query = string.Format(DatabaseConstants.AddTask,
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

        public async Task<bool> UpdateEntryAsync(Comment taskdata)
        {

            object queryResult;
            try
            {
                using (var dbConnection = new NpgsqlConnection(this.connectionStr))
                {
                    dbConnection.Open();
                    var query = string.Format(DatabaseConstants.UpdateTask,
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
                    var query = string.Format(DatabaseConstants.DeleteTask, currentTime, id);
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
