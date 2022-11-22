using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIwork.Models
{
    public partial class Product
    {
        public int? IdProduct { get; set; }
        public string NameProduct { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Sell { get; set; }
        public byte[] Image { get; set; } = null!;
    }

}
