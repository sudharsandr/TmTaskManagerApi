using TmTaskManagerApi.HttpHelpers.Models;

namespace TmTaskManagerApi.HttpHelpers
{
    public  class ResponseGenerator<T>
    {
        public  ApiResponse<T> GenerateResponse(T? responseObj, string? error, string? remarks )
        {
            ApiResponse<T> HttpResponse = new ApiResponse<T>();
            HttpResponse.StatusCode = System.Net.HttpStatusCode.OK;
            if(responseObj != null)
                HttpResponse.Response = responseObj;

            if (error != null)
            { 
                HttpResponse.Error = error;
                HttpResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }


            if (remarks != null)
                HttpResponse.Remarks = remarks;

            return HttpResponse;
        }
    }
}
