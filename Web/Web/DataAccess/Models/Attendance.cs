using System;
using System.Collections.Generic;

namespace Web.DataAccess.Models
{
    public partial class Attendance
    {
        public int AttendanceId { get; set; }
        public int ScheduleDetailId { get; set; }
        public int UserId { get; set; }
        public bool Attendance1 { get; set; }

        public virtual ScheduleDetail ScheduleDetail { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
