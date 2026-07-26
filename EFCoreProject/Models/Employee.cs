using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreProject.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int EmployeeSsn { get; set; }
        public string EmpName { get; set; }
        public int EmployeeAge { get; set; }
        public double EmployeeSalary { get; set; }
    }
}
