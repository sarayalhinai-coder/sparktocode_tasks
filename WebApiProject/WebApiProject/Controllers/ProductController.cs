using WebApiProject.Models;

namespace WebApiProject.Controllers
{
    public class ProductController
    {
        private ProjectCantext context;

        public ProductController(ProjectCantext _context)
        {
            context = _context;
        }

        public void AddProduct(Product p)
        {
            context.Products.Add(p);
            context.SaveChanges();
            
        }

        public void RemoveProduct(int id) 
        {
            Product p = context.Products.FirstOrDefault(p => p.ProductId == id);

            if (p == null)
            {
                
            }
            else
            {
                context.Products.Remove(p);
                context.SaveChanges();
                
            }
        }
    }
}
