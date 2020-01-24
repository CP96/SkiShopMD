using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SkiShopMD.Models
{
    public partial class Snowboards
    {
        public long SnowboardsId { get; set; }
        public string Products { get; set; }
        public string Model { get; set; }
        public int Lenght { get; set; }
        public decimal Price { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Quantity must be a positive number")]
        public long Quantity { get; set; }
        public DateTime CratedDate { get; set; }
    }
}
