using System;
using System.Collections.Generic;

namespace Web.DataAccess.Models
{
    public partial class Semester
    {
        public Semester()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int SemesterId { get; set; }
        public string SemesterName { get; set; } = null!;

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
