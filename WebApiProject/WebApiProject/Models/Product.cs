using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiProject.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice {  get; set; }

        [ForeignKey("_category")]
        public int CategoryId { get; set; }
        public Category _category { get; set; }

    }
}
