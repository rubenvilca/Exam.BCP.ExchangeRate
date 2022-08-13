using System.Collections.Generic;

namespace BCP.ExchangeRate.WebAPI.Models.Response
{
    public class WebApiResponse<T>
    {
        public bool Success { get; set; }
        public Response<T> Response { get; set; }
        public List<Error> Errors { get; set; }

        public WebApiResponse()
        {
            this.Errors = new List<Error>();
            this.Success = false;
        }
    }

    public class Response<T>
    {
        public List<T> Data { get; set; }
    }

    public class Error
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
}