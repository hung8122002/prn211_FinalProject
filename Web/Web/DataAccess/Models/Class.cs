using System;
using System.Collections.Generic;

namespace Web.DataAccess.Models
{
    public partial class Class
    {
        public Class()
        {
            ClassDetails = new HashSet<ClassDetail>();
            Schedules = new HashSet<Schedule>();
        }

        public int ClassId { get; set; }
        public string ClassName { get; set; } = null!;

        public virtual ICollection<ClassDetail> ClassDetails { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
