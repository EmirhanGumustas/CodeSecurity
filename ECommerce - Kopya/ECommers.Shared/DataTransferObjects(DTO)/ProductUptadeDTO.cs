﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommers.Shared.DataTransferObjects_DTO_
{
    public class ProductUptadeDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Properties { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int[] CategoryIds { get; set; }
    }
}