using ECommers.Entity.Abstrack;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommers.Entity.Concrate
{
    public class OrderItem : BaseEntity
    {

        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal UnitPrice {  get; set; } // fiyatta değişiklik olursa.
        public int Quantity { get; set; }
    }
}
