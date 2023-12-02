using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;
using Test2FAApplicationWebaPI.Common;
using Test2FAApplicationWebaPI.ImplementService;
using Test2FAApplicationWebaPI.InterfaceService;

namespace Test2FAApplicationWebaPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private IEmployee _IEmployeeRepository;
        private readonly APIResponse _response;
        public EmployeeController()
        {
            this._IEmployeeRepository = new EmployeeRepository();
            this._response = new APIResponse();
        }

        bool status = true;
        string message = string.Empty;

        [Route("GetCodeByMobileNo")]
        [HttpGet]
        public IActionResult GetCodeByMobileNo(string mobileno)
        { 
            try
            {
                string? code = _IEmployeeRepository.GetEmployeeByMobile(mobileno);
                if (!string.IsNullOrEmpty(code))
                {
                    return _response.GenerateAPIResult(HttpStatusCode.OK, true, "Success", code);
                }
                else
                { 
                    return _response.GenerateAPIResult(HttpStatusCode.NoContent, false, "");
                }
            }
            catch (Exception ex)
            { 
                return _response.GenerateAPIResult(HttpStatusCode.BadRequest, false, "");
            } 
        }

        [Route("VerifiedPhonenobyCode")]
        [HttpGet]
        public IActionResult VerifiedPhonenobyCode(string code)
        { 
            try
            {
                var isVerifycode = _IEmployeeRepository.VerifiedEmployeeByCode(code);
                if (isVerifycode == true)
                { 
                    return _response.GenerateAPIResult(HttpStatusCode.OK, true, "Code and MobileNo Verify Successfully.");
                }
                else
                { 
                    return _response.GenerateAPIResult(HttpStatusCode.NoContent, false, "Invalid Code or MobileNo.");
                }
            }
            catch (Exception ex)
            {
                return _response.GenerateAPIResult(HttpStatusCode.BadRequest, false, "");
            } 
        }
    }
}
