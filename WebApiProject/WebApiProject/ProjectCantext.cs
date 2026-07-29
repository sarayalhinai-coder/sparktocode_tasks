using Microsoft.EntityFrameworkCore;
using WebApiProject.Models;

namespace WebApiProject
{
    public class ProjectCantext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ProjectCantext(DbContextOptions<ProjectCantext> options) : base(options)
        {

        }
    }
}
