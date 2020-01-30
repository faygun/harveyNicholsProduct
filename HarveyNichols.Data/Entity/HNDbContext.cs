using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarveyNichols.Data.Entity
{
    public class HNDbContext : DbContext
    {
        public virtual DbSet<Product> Product { get; set; }

    }
}
