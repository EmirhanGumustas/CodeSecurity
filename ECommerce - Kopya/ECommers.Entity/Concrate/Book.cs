using ECommers.Entity.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommers.Entity.Concrate
{
    public class Book : BaseEntity
    {
        public string PublishingHouse { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }
    }
}
