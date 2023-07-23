using System;
using System.Collections.Generic;

namespace Web.DataAccess.Models
{
    public partial class User
    {
        public User()
        {
            Attendances = new HashSet<Attendance>();
            ClassDetails = new HashSet<ClassDetail>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string? FullName { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<ClassDetail> ClassDetails { get; set; }
    }
}
