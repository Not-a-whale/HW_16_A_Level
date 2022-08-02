using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW16.DbModels
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HiredDate { get; set; }
        [DataType("datetime2")]
        public DateTime DateOfBirth { get; set; }
        public int OfficeId { get; set; }
        public virtual Office Office { get; set; }
        public int TitleId { get; set; }
        public virtual Title Title { get; set; }
    }
}
