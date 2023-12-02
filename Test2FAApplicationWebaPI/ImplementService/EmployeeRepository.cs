using Microsoft.Extensions.Logging;
using Test2FAApplicationWebaPI.Context;
using Test2FAApplicationWebaPI.DBModels;
using Test2FAApplicationWebaPI.InterfaceService;

namespace Test2FAApplicationWebaPI.ImplementService
{
    public class EmployeeRepository : IEmployee, IDisposable
    {
        private EmployeeDBContext dbContext;
        public EmployeeRepository(EmployeeDBContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public EmployeeRepository()
        {
            dbContext = new EmployeeDBContext();
        }

        public void AddEmployee(string email, string mobile)
        {
            try
            {
                EmployeeMaster employeeMaster = new EmployeeMaster();
                employeeMaster.EmailId = email;
                employeeMaster.MobileNo = mobile;
                employeeMaster.CreatedDate = DateTime.Now;
                employeeMaster.IsVerified = false;
                dbContext.Add(employeeMaster);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }

        public void UpdateEmployee(string code)
        {
            try
            {
                EmployeeMaster eModel = dbContext.EmployeeMasters.Where(m => m.Code == code).First();
                eModel.UpdatedDate = DateTime.Now;
                eModel.IsVerified = true;
                dbContext.Update(eModel);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }

        public bool VerifiedEmployeeByCode(string code)
        {
            try
            {
                bool isVerified = false;
                var getData = dbContext.EmployeeMasters.Where(x => x.Code == code).FirstOrDefault();
                if (getData != null)
                {
                    isVerified = true;
                }
                return isVerified;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string? GetEmployeeByMobile(string mobileno)
        {
            string returnCode = string.Empty;
            try
            { 
                var getData = dbContext.EmployeeMasters.Where(x => x.MobileNo == mobileno).FirstOrDefault();
                if (getData != null)
                {
                    returnCode = getData.Code;
                }
                return returnCode;
            }
            catch (Exception ex)
            {
                return returnCode;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false;  

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        } 
        #endregion
    }
}
