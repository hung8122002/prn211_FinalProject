using System;
using System.Collections.Generic;

namespace Web.DataAccess.Models
{
    public partial class Course
    {
        public Course()
        {
            Schedules = new HashSet<Schedule>();
            Teachers = new HashSet<Teacher>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public string CourseDescription { get; set; } = null!;
        public int TotalSlot { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
