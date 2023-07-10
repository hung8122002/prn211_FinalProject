using Web.DataAccess.Models;

namespace Web.Bussiness.DTO
{
    public class ScheduleDTO
    {
        public int ScheduleId { get; set; }
        public int ClassId { get; set; }
        public int SemesterId { get; set; }
        public int CourseId { get; set; }
        public int RoomId { get; set; }
        public int Slot { get; set; }
        public DateTime Date { get; set; }
        public bool Attendance { get; set; }

        public virtual ClassDTO Class { get; set; } = null!;
        public virtual CourseDTO Course { get; set; } = null!;
        public virtual RoomDTO Room { get; set; } = null!;
    }
}
