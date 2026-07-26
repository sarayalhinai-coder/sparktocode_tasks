using EFCoreProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreProject
{
    public class ProjectContext : DbContext
    {
       public DbSet<Employee> employees {  get; set; }
       public DbSet<Department> departments { get; set; }

        public DbSet<Project> projects { get; set; }
        public DbSet<Dependent> dependents { get; set; }

        public DbSet<DeptLocation> DeptLocations { get; set; }

        public DbSet<empProj> empProjs { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(
            "Server=.\\SQLEXPRESS;Database=CompanyProjectDB;Trusted_Connection=True;TrustServerCertificate=True;" // connection string
            );
        }
    }
}
