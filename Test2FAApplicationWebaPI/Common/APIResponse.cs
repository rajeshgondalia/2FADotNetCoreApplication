using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Test2FAApplicationWebaPI.Common
{
    public class APIResponse
    {
        public IActionResult GenerateAPIResult(HttpStatusCode statusCode, bool status, string message = null, object data = null, string token = null)
        {
            return new JsonResult(new JsonResponseHelper
            {
                Statuscode = statusCode,
                Status = status,
                Data = data,
                Message = message,
                Token = token
            });
        }
    }

    public class JsonResponseHelper
    {
        public HttpStatusCode Statuscode;
        public bool Status;
        public string Message;
        public object Data;
        public string Token;
    }
}
