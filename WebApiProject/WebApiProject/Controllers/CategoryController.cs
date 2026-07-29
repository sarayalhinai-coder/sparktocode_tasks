using WebApiProject.Models;


namespace WebApiProject.Controllers
{
    public class CategoryController
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

    }
}
