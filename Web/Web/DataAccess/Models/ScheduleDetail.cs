using System;
using System.Collections.Generic;

namespace Web.DataAccess.Models
{
    public partial class ScheduleDetail
    {
        public int ScheduleDetailId { get; set; }
        public int ScheduleId { get; set; }
        public int SlotId { get; set; }
        public int RoomId { get; set; }
        public DateTime Date { get; set; }
        public bool Attendance { get; set; }

        public virtual Slot Slot { get; set; } = null!;
    }
}
