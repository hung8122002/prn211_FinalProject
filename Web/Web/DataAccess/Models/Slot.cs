using System;
using System.Collections.Generic;

namespace Web.DataAccess.Models
{
    public partial class Slot
    {
        public Slot()
        {
            ScheduleDetails = new HashSet<ScheduleDetail>();
        }

        public int SlotId { get; set; }
        public string SlotName { get; set; } = null!;

        public virtual ICollection<ScheduleDetail> ScheduleDetails { get; set; }
    }
}
