using System;
using System.Collections.Generic;

namespace Web.DataAccess.Models
{
    public partial class ScheduleDetail
    {
        public ScheduleDetail()
        {
            Attendances = new HashSet<Attendance>();
        }

        public int ScheduleDetailId { get; set; }
        public int SheduleId { get; set; }
        public int RoomId { get; set; }
        public int Slot { get; set; }
        public DateTime Date { get; set; }

        public virtual Room Room { get; set; } = null!;
        public virtual Schedule Shedule { get; set; } = null!;
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
