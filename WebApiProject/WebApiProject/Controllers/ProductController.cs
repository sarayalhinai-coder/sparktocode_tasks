using Microsoft.AspNetCore.Mvc;
using WebApiProject.Models;

namespace WebApiProject.Controllers
{
    [ApiController]
    [Route("Product")]

    public class ProductController : ControllerBase
    {
        private ProjectCantext context;

        public ProductController(ProjectCantext _context)
        {
            context = _context;
        }
        [HttpPost("AddProduct")]
        public IActionResult AddProduct(Product p)
        {
            context.Products.Add(p);
            context.SaveChanges();
            return Ok(p.ProductId);
            
        }

        [HttpDelete("RemoveProduct")]
        public IActionResult RemoveProduct(int id) 
        {
            Product p = context.Products.FirstOrDefault(p => p.ProductId == id);

            if (p == null)
            {
                return NotFound("product not found");
            }
            else
            {
                context.Products.Remove(p);
                context.SaveChanges();
                return Ok ("removed successfully");
            }
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            Product p = context.Products.FirstOrDefault(p => p.ProductId == id);
            return Ok(p);
        }

        [HttpGet("GetALLProducts")]
        public IActionResult GetALLProducts()
        {
            List<Product> products = context.Products.ToList();
            return Ok(products);
        }

        [HttpGet("GetByName")]
        public IActionResult GetByName(string name)
        {
            List<Product> products = context.Products.Where(p => p.ProductName.Contains(name)).ToList();
            return Ok(products);
        }


        [HttpPatch("UpdateProductPrice")]
        public IActionResult UpdateProductPrice(int id, double newPrice)
        {
            Product p = context.Products.FirstOrDefault(p => p.ProductId == id);

            p.ProductPrice = newPrice;

            context.SaveChanges();

            return Ok();
        }

        [HttpPatch("UpdateProductName")]
        public IActionResult UpdateProductName(int id, string newName)
        {
            Product p = context.Products.FirstOrDefault(p => p.ProductId == id);

            p.ProductName = newName;

            context.SaveChanges();

            return Ok();
        }

        [HttpPut("UpdateProduct")]
        public IActionResult UpdateProduct(int id, Product newProduct)
        {
            Product p = context.Products.FirstOrDefault(p => p.ProductId == id);

            p.ProductPrice = newProduct.ProductPrice;
            p.ProductName = newProduct.ProductName;
            p.ProductDescription = newProduct.ProductDescription;

            context.SaveChanges();

            return Ok();
        }
    }
}
