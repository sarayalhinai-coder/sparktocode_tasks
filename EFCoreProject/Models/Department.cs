using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCoreProject.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; } //1,2,3

        public int DepartmentNumber { get; set; } //10,20,30

        public string DepartmentName { get; set; }

        //worksfor
        [InverseProperty("D")]
        public List<Employee> Employees { get; set; }

        //manage
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime ManageStartDate { get; set; }
    }
}
