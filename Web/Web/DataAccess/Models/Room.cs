using System;
using System.Collections.Generic;

namespace Web.DataAccess.Models
{
    public partial class Room
    {
        public Room()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int RoomId { get; set; }
        public string RoomName { get; set; } = null!;

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
