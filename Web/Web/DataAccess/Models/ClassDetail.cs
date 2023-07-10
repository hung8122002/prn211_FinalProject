using System;
using System.Collections.Generic;

namespace Web.DataAccess.Models
{
    public partial class ClassDetail
    {
        public int ClassDetailId { get; set; }
        public int ClassId { get; set; }
        public int UserId { get; set; }

        public virtual Class Class { get; set; } = null!;
        public virtual User ClassNavigation { get; set; } = null!;
    }
}
