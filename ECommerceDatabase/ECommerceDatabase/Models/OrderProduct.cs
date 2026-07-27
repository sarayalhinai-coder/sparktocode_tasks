using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerceDatabase.Models
{
    [PrimaryKey(nameof(OrderId), nameof(ProductId))]
    public class OrderProduct
    {
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public  Order Order { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public  Product Product { get; set; }

        public int Quantity { get; set; }

    }
}
