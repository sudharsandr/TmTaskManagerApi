using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Dapper;
using TmTaskManagerApi.BusinessLogic.Implementation;
using TmTaskManagerApi.BusinessLogic.Structure;
using TmTaskManagerApi.Models;
using TmTaskManagerApi.HttpHelpers;
using TmTaskManagerApi.HttpHelpers.Models;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TmTaskManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private ITaskLogic TaskLogic { get; set; }
        public TaskController(ITaskLogic _taskLogic)
        {
            TaskLogic = _taskLogic;
        }

        // GET: api/<TaskController>
        [HttpGet]
        public async Task<ApiResponse<List<Tasks>>?> GetAsync()
        {
            ApiResponse<List<Tasks>>? response = null;
            List<Tasks>? tasks = null;
            string? error = null;
            string? remarks = null;
            tasks = await TaskLogic.GetAllTaskAsync();
            if (tasks == null || tasks.Count == 0)
            {
                remarks = ApiConstants.NoTasks;

            }
            response = new ResponseGenerator<List<Tasks>>().
                    GenerateResponse(tasks, error, remarks: remarks);
            return response;
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public async Task<ApiResponse<Tasks>?> GetAsync(int id)
        {
            ApiResponse<Tasks>? response = null;
            Tasks? taskObj = null;
            string? error = null;
            string? remarks = null;
            if (id == 0)
            {
                error = ApiConstants.TaskIdNeeded;
            }
            else
            {
                taskObj = await TaskLogic.GetTaskAsync(id);
                if (taskObj == null)
                    error = ApiConstants.NoTaskFound;
            }
            response = new ResponseGenerator<Tasks>().
                    GenerateResponse(taskObj, error, remarks: remarks);
            return response;
        }

        // POST api/<TaskController>
        [HttpPost]
        public async Task<ApiResponse<bool>?> PostAsync([FromBody] Tasks taskData)
        {
            ApiResponse<bool>? response = null;
            string? error = null;
            string? remarks = null;
            bool addResponse = false;
            try
            {
                if (taskData.title.IsNullOrEmptyOrWhiteSpace() ||
                    taskData.description.IsNullOrEmptyOrWhiteSpace() ||
                    taskData.task_type.IsZero() ||
                    taskData.status_id.IsZero() ||
                    taskData.assigned_to.IsZero() ||
                    taskData.required_date < DateTime.Now)
                {
                    error = ApiConstants.ValuesMissing;
                }
                else
                {
                    addResponse = await TaskLogic.AddTaskAsync(taskData);
                    if(!addResponse)
                        error = ApiConstants.UnhandledError;
                }
                response = new ResponseGenerator<bool>().
                    GenerateResponse(addResponse, error, remarks: remarks);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return response;
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
