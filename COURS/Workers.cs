using System;
using System.Collections.Generic;

namespace APIwork.Models
{
    public partial class Workers
    {
        public int? IdWorker { get; set; }
        public string NameWorker { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public decimal Inn { get; set; }
        public int RoleId { get; set; }
        public int PostId { get; set; }

        //public virtual Post Post { get; set; } = null!;
        //public virtual Role Role { get; set; } = null!;
    }
}
