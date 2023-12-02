using Google.Authenticator;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Test2FAApplication.Models;
using Test2FAApplicationWebaPI.DBModels;
using Test2FAApplicationWebaPI.ImplementService;
using Test2FAApplicationWebaPI.InterfaceService;

namespace Test2FAApplication.Controllers
{
    public class TwoFactorAuthenticationController : Controller
    {

        private IEmployee _IEmployeeRepository;
        public TwoFactorAuthenticationController()
        {
            this._IEmployeeRepository = new EmployeeRepository();
        }

        [HttpGet]
        public ActionResult Index()
        {
            UserModel model = new UserModel();
            ViewBag.IsAuthDisplay = false;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(string email, string mobile)
        {
            ViewBag.IsAuthDisplay = true;
            TwoFactorAuthenticator twoFactor = new TwoFactorAuthenticator();
            var secretCode = Guid.NewGuid().ToString().Replace("-", "")[0..10];
            var accountSecretKey = $"{secretCode}-{email}";
            var setupInfo =
                twoFactor.GenerateSetupCode("2FA", email,
                Encoding.ASCII.GetBytes(accountSecretKey));
            ViewBag.SetupCode = setupInfo.ManualEntryKey;
            ViewBag.BarcodeImageUrl = setupInfo.QrCodeSetupImageUrl;

            _IEmployeeRepository.AddEmployee(email, mobile);

            return View();
        }

        [HttpPost]
        public ActionResult EnableAuth(string inputCode)
        {
            UserModel user = new UserModel();
            user.Email = "rajeshgondalia1402@gmail.com";
            TwoFactorAuthenticator twoFactor = new TwoFactorAuthenticator();
            var secretCode = Guid.NewGuid().ToString().Replace("-", "")[0..10];
            var accountSecretKey = $"{secretCode}-{user.Email}";
            bool isValid = twoFactor.ValidateTwoFactorPIN(Encoding.ASCII.GetBytes(accountSecretKey), inputCode);
            if (!isValid)
            {
                return Redirect("/TwoFactorAuthentication/Index");
            }
            else
            {
                EmployeeMaster employeeMaster = new EmployeeMaster();

                _IEmployeeRepository.UpdateEmployee(inputCode);
            }
            return Redirect("/");
        }
    }
}
