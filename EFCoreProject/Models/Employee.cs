using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCoreProject.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public int EmployeeSsn { get; set; }
        public string EmpName { get; set; }
        public int EmployeeAge { get; set; }
        public double EmployeeSalary { get; set; }


        //worksfor 1 - M
        [ForeignKey("D")]
        public int DepartmentID { get; set; }
        public Department D { get; set; }
        //manage
        [InverseProperty("Employee")]
        public Department ManagedDepart { get; set; }
        //dependent 1 -1
        public Dependent Dependent { get; set; }


        //worksOn M-M
        // public List<Project> projects { get; set; }

        public List<empProj> empProjs { get; set; }



        //supervision
        [InverseProperty("supervisor")]
        public List<Employee> supervisee { get; set; }


        [ForeignKey("supervisor")]
        public int SupervisorID { get; set; }
        public Employee supervisor { get; set; }

    }
}
