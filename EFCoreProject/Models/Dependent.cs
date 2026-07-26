using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCoreProject.Models
{
    [PrimaryKey(nameof(EmployeeId), nameof(DependentName))]
    public class Dependent
    {
        public int DependentID { get; set; }
        public string DependentName { get; set; }
        public string relationsship { get; set; }


        [ForeignKey("emp")]
        public int EmployeeId { get; set; }
        public Employee emp { get; set; }

    }
}
