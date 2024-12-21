using ECommers.Entity.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommers.Entity.Concrate
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public string? Properties { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<ProductCategory>? ProductCategories { get; set; } = new HashSet<ProductCategory>();  // listeyi barındırır deafult değer atama yaptık 
        // hashset = verileri hızlı çekebilmemize yarıyor.

        // liste yerine IEnumerable yazılabilir ama sadece okuma olur ekleme silme uptade işlemini karşılamaz.
        // ICollection veri  silme ekleme uptade kullanılır. okuma da olabilir.
        //liste ise index[0] için ekstra olarak bu özellik olur . üstteki özelliklerde olur.
    }
}
