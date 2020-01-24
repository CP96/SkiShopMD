using System;
using System.Collections.Generic;

namespace SkiShopMD.Models
{
    public partial class Skis
    {
        public long SkisId { get; set; }
        public string Producer { get; set; }
        public string Model { get; set; }
        public int Lenght { get; set; }
        public decimal Price { get; set; }
        public long Quantity { get; set; }
        public DateTime CratedDate { get; set; }
    }
}
