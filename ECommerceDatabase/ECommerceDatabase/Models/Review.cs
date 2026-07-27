using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerceDatabase.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int ReviewRating { get; set; }
        public string ReviewComment { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
