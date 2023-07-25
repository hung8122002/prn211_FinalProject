using Web.Bussiness.DTO;
using Web.DataAccess.Models;

namespace Web.Bussiness.IRepository
{
    public interface IScheduleRepository
    {
        public List<AttendanceDTO> GetScheduleDetails(int userId, DateTime startDate, DateTime endDate);
        public List<SemesterDTO> GetSemester();
        public List<ScheduleDTO> GetSchedulesBySemester(int userId, int semesterId, int year);
        public List<AttendanceDTO> GetAttendance(int userId, int scheduleId);
        public List<ScheduleDetailDTO> GetTeacherSchedule(int userId, DateTime date);
        public List<AttendanceDTO> GetClassAttendances(int scheduleDetailId);
        public void UpdateClassAttendance(int attendanceId, bool status);
    }
}
