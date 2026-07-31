using Microsoft.AspNetCore.Mvc;
using WebApiProject.Models;


namespace WebApiProject.Controllers
{
    //[ApiController]
    //[Route("Category")]
    public class CategoryController //: ControllerBase
    {
        private ProjectCantext context;

        public CategoryController(ProjectCantext _context)
        {
            context = _context;
        }

        public void AddCategory(Category c)
        {

            context.Categories.Add(c);
            context.SaveChanges();

        }


        public void RemoveCategory(int id)
        {

            Category c = context.Categories.FirstOrDefault(c => c.CategoryId == id);

            if (c == null)
            {
            }
            else
            {
                context.Categories.Remove(c);
                context.SaveChanges();
            }
        }

        public Category GetCategory(int id)
        {
            Category C = context.Categories.FirstOrDefault(c => c.CategoryId == id);
            return C;
        }

        public List<Category> GetALLCategories()
        {
            List<Category> categories = context.Categories.ToList();
            return categories;
        }

    }
}
