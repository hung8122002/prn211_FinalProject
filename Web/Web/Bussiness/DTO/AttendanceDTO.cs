using Web.DataAccess.Models;

namespace Web.Bussiness.DTO
{
    public class AttendanceDTO
    {
        public int AttendanceId { get; set; }
        public int ScheduleDetailId { get; set; }
        public int UserId { get; set; }
        public bool Attendance1 { get; set; }

        public virtual ScheduleDetailDTO ScheduleDetail { get; set; } = null!;
        public virtual UserDTO User { get; set; } = null!;
    }
}
