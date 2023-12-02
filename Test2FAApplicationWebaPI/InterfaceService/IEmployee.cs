using Test2FAApplicationWebaPI.DBModels;

namespace Test2FAApplicationWebaPI.InterfaceService
{
    public interface IEmployee
    {
        void AddEmployee(string email,string mobile);
        void UpdateEmployee(string code); 
        bool VerifiedEmployeeByCode(string code);
        string? GetEmployeeByMobile(string mobileno);
    }
}
