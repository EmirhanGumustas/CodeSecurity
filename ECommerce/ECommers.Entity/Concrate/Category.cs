using ECommers.Entity.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommers.Entity.Concrate
{
    public class Category : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<ProductCategory>? ProductCategories { get; set; } = new HashSet<ProductCategory>();
    }
}
