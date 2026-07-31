using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiProject.Models
{
    public class Category
    {
        [Key]
        [JsonIgnore]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string CategoryDescription { get; set; }

        [JsonIgnore]
        public List<Product>? Products { get; set; }
    }
}
