using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test2FAApplicationWebaPI.DBModels
{
    [Table("EmployeeMaster", Schema = "dbo")]
    public partial class EmployeeMaster
    {
        public int Id { get; set; }
        public string EmailId { get; set; } = null!;
        public string MobileNo { get; set; } = null!;
        public string Code { get; set; } = null!;
        public bool IsVerified { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
