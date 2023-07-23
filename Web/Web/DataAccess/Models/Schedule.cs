using System;
using System.Collections.Generic;

namespace Web.DataAccess.Models
{
    public partial class Schedule
    {
        public Schedule()
        {
            ScheduleDetails = new HashSet<ScheduleDetail>();
        }

        public int ScheduleId { get; set; }
        public int ClassId { get; set; }
        public int SemesterId { get; set; }
        public int CourseId { get; set; }
        public int Year { get; set; }

        public virtual Class Class { get; set; } = null!;
        public virtual Course Course { get; set; } = null!;
        public virtual Semester Semester { get; set; } = null!;
        public virtual ICollection<ScheduleDetail> ScheduleDetails { get; set; }
    }
}
