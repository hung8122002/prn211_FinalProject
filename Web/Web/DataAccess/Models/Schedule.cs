using System;
using System.Collections.Generic;

namespace Web.DataAccess.Models
{
    public partial class Schedule
    {
        public int ScheduleId { get; set; }
        public int ClassId { get; set; }
        public int SemesterId { get; set; }
        public int CourseId { get; set; }
        public int RoomId { get; set; }
        public int Slot { get; set; }
        public DateTime Date { get; set; }
        public bool Attendance { get; set; }

        public virtual Class Class { get; set; } = null!;
        public virtual Course Course { get; set; } = null!;
        public virtual Room Room { get; set; } = null!;
        public virtual Semester Semester { get; set; } = null!;
    }
}
