using AutoMapper;
using Web.Bussiness.DTO;
using Web.Bussiness.IRepository;
using Web.DataAccess.Manager;
using Web.DataAccess.Models;

namespace Web.Bussiness.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        PRN211_FinalProjectContext _projectContext;
        IMapper _mapper;
        ScheduleManager scheduleManager;

        public ScheduleRepository(PRN211_FinalProjectContext projectContext, IMapper mapper)
        {
            _projectContext = projectContext;
            _mapper = mapper;
            scheduleManager= new(_projectContext);
        }

        public List<AttendanceDTO> GetAttendance(int userId, int scheduleId)
        {
            List<Attendance> scheduleDetails = scheduleManager.GetAttendance(userId, scheduleId);
            List<AttendanceDTO> scheduleDetailDTOs = _mapper.Map<List<AttendanceDTO>>(scheduleDetails);
            return scheduleDetailDTOs;
        }

        public List<AttendanceDTO> GetClassAttendances(int scheduleDetailId)
        {
            List<Attendance> scheduleDetails = scheduleManager.GetClassAttendances(scheduleDetailId);
            List<AttendanceDTO> scheduleDetailDTOs = _mapper.Map<List<AttendanceDTO>>(scheduleDetails);
            return scheduleDetailDTOs;
        }

        public List<AttendanceDTO> GetScheduleDetails(int userId, DateTime startDate, DateTime endDate)
        {
            List<Attendance> scheduleDetails = scheduleManager.GetScheduleDetails(userId, startDate, endDate);
            List<AttendanceDTO> scheduleDetailDTOs = _mapper.Map<List<AttendanceDTO>>(scheduleDetails);
            return scheduleDetailDTOs;
        }

        public List<ScheduleDTO> GetSchedulesBySemester(int userId, int semesterId, int year)
        {
            List<Schedule> schedules = scheduleManager.GetSchedulesBySemester(userId, semesterId, year);
            List<ScheduleDTO> scheduleDTOs = _mapper.Map<List<ScheduleDTO>>(schedules);
            return scheduleDTOs;
        }

        public List<SemesterDTO> GetSemester()
        {
            List<Semester> schedules = scheduleManager.GetSemester();
            List<SemesterDTO> scheduleDTOs = _mapper.Map<List<SemesterDTO>>(schedules);
            return scheduleDTOs;
        }

        public List<ScheduleDetailDTO> GetTeacherSchedule(int userId, DateTime date)
        {
            List<ScheduleDetail> scheduleDetails = scheduleManager.GetTeacherSchedule(userId, date);
            List<ScheduleDetailDTO> scheduleDetailDTOs = _mapper.Map<List<ScheduleDetailDTO>>(scheduleDetails);
            return scheduleDetailDTOs;
        }

        public void UpdateClassAttendance(int attendanceId, bool status)
        {
            scheduleManager.UpdateClassAttendance(attendanceId, status);
        }
    }
}
