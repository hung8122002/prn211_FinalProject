using System;
using System.Collections.Generic;

namespace Web.DataAccess.Models
{
    public partial class Teacher
    {
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public int UserId { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
