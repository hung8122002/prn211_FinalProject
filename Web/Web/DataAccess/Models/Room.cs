using System;
using System.Collections.Generic;

namespace Web.DataAccess.Models
{
    public partial class Room
    {
        public Room()
        {
            ScheduleDetails = new HashSet<ScheduleDetail>();
        }

        public int RoomId { get; set; }
        public string RoomName { get; set; } = null!;

        public virtual ICollection<ScheduleDetail> ScheduleDetails { get; set; }
    }
}
