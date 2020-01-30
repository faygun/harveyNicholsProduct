using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarveyNichols.Data.Entity
{
    public class Product : BaseEntity
    {
        public int ProductId { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public byte Colour { get; set; }
        public byte Style { get; set; }
        public string Sku { get; set; }
        public string Title { get; set; }
    }
}
