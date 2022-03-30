using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PangWeb.Shared.DTOs
{
    public class ShoppingCartDto
    {
        public List<ShoppingCartItemDto> Items { get; set; }
        public int TotalPrice { get; set; }
        public int NoOfItems { get; set; }
    }
}
