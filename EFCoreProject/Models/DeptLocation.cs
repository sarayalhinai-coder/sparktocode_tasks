using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCoreProject.Models
{
    [PrimaryKey(nameof(DepartmentID), nameof(DepartmentLocation))]
    public class DeptLocation
    {
        [ForeignKey("Dept")]
        public int DepartmentID { get; set; } 
        public Department Dept { get; set; }


        public string DepartmentLocation { get; set; }

    }
}
