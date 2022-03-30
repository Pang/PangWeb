using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PangWeb.Shared.DTOs
{
    public class ShoppingCartItemDto
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}
