using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HarveyNicholsProduct.Models
{
    public class ProductRequest
    {
        public byte Style { get; set; }
        public byte Colour { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Title { get; set; }
    }
}