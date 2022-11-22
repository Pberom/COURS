using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIwork.Models
{
    public partial class Role
    {
        //public Role()
        //{
        //    Users = new HashSet<User>();
        //    Workers = new HashSet<Worker>();
        //}

        public int? IdRole { get; set; }
        public string NameRole { get; set; } = null!;

        //public virtual ICollection<User> Users { get; set; }
        //public virtual ICollection<Worker> Workers { get; set; }
    }
}
