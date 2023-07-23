using Web.DataAccess.Models;

namespace Web.Bussiness.DTO
{
    public class ScheduleDetailDTO
    {
        public int ScheduleDetailId { get; set; }
        public int SheduleId { get; set; }
        public int RoomId { get; set; }
        public int Slot { get; set; }
        public DateTime Date { get; set; }

        public virtual RoomDTO Room { get; set; } = null!;
        public virtual ScheduleDTO Shedule { get; set; } = null!;
    }
}
