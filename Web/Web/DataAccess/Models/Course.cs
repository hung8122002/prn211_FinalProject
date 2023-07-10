using System;
using System.Collections.Generic;

namespace Web.DataAccess.Models
{
    public partial class Course
    {
        public Course()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public string CourseDescription { get; set; } = null!;

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
