using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarveyNichols.DTO.Product
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string Sku { get; set; }
        public byte Style { get; set; }
        public byte Colour { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
