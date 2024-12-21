using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommers.Shared.DataTransferObjects_DTO_
{
    public class ProducrCreateDTO
    {
        public string? Name { get; set; }
        public string? Properties { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int[] CategoryIds { get; set; }
    }
}
/*
 * {
 *      NAME ="IPHINE 15",
 *      PROP = "HARİKA TEL,"
 *      PRİCE=12313,
 *      İMAGEURL=2139873872879132.PNG,
 *      CategoryIds=[4.7.12];
 */