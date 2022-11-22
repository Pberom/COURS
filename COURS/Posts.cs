using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIwork.Models
{
    public partial class Posts
    {
        public int? IdPost { get; set; }
        public string NamePost { get; set; } = null!;
        public decimal Sell { get; set; }
        public int StatusId { get; set; }
    }
}
