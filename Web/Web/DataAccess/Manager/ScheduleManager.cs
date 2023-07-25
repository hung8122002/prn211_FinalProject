using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Web.DataAccess.Models;

namespace Web.DataAccess.Manager
{
    public class ScheduleManager
    {
        PRN211_FinalProjectContext _projectContext;

        public ScheduleManager(PRN211_FinalProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public List<Attendance> GetScheduleDetails(int userId, DateTime startDate, DateTime endDate)
        {
            List<Attendance> attendances = _projectContext.Attendances
    .Include(a => a.User)
    .Include(a => a.ScheduleDetail).ThenInclude(c => c.Shedule).ThenInclude(c => c.Course)
    .Include(a => a.ScheduleDetail).ThenInclude(c => c.Shedule).ThenInclude(c => c.Semester)
    .Include(a => a.ScheduleDetail).ThenInclude(c => c.Shedule).ThenInclude(c => c.Class)
    .Include(a => a.ScheduleDetail).ThenInclude(c => c.Room)
    .Where(a => a.UserId == userId && a.ScheduleDetail.Date >= startDate && a.ScheduleDetail.Date <= endDate)
    .OrderBy(a => a.ScheduleDetail.Date)
    .ToList();
            return attendances;
        }

        public List<Semester> GetSemester()
        {
            List<Semester> semesters = _projectContext.Semesters.ToList();
            return semesters;
        }

        public List<Schedule> GetSchedulesBySemester(int userId, int semesterId, int year)
        {
            List<ClassDetail> ClassDetail = _projectContext.ClassDetails.Where(c => c.UserId == userId).ToList();
            List<Schedule> Schedules = new();
            foreach (var item in ClassDetail)
            {
                List<Schedule> schedules = _projectContext.Schedules
                    .Include(c => c.Course).Include(c => c.Semester)
                    .Where(c => c.Class.ClassId == item.ClassId && c.Semester.SemesterId == semesterId && c.Year == year)
                    .ToList();

                if (schedules != null)
                {
                    Schedules.AddRange(schedules);
                }
            }
            return Schedules;
        }

        public List<Attendance> GetAttendance(int userId, int scheduleId)
        {
            List<Attendance> attendances = _projectContext.Attendances.Include(c => c.ScheduleDetail).ThenInclude(c => c.Shedule).ThenInclude(c => c.Class)
                .Include(c => c.ScheduleDetail).ThenInclude(c => c.Room)
                .Where(c => c.ScheduleDetail.Shedule.ScheduleId == scheduleId && c.UserId == userId).ToList();
            return attendances;
        }

        public List<ScheduleDetail> GetTeacherSchedule(int userId, DateTime date)
        {
            List<ClassDetail> ClassDetail = _projectContext.ClassDetails.Where(c => c.UserId == userId).ToList();
            //các lớp mà giáo viên đó dạy học vào ngày đó
            List<ScheduleDetail> Schedules = new();
            foreach (var item in ClassDetail)
            {
                List<ScheduleDetail> schedules = _projectContext.ScheduleDetails.Include(c => c.Shedule).ThenInclude(c => c.Class).Where(c => c.Shedule.ClassId == item.ClassId && c.Date == date).ToList();
                if (schedules != null)
                {
                    Schedules.AddRange(schedules);
                }
            }

            //Kiểm tra xem các lớp đã tìm ra có phải giáo viên ngày dạy môn hôm đó học không
            List<ScheduleDetail> Schedules1 = new();
            List<Teacher> teachers = _projectContext.Teachers.Include(c => c.Course).Where(c => c.UserId == userId).ToList();
            foreach (var item in Schedules)
            {
                foreach (var item1 in teachers)
                {
                    if(item.Shedule.CourseId == item1.CourseId)
                    {
                        Schedules1.Add(item);
                    }
                }
            }
            return Schedules1;
        }

        public List<Attendance> GetClassAttendances(int scheduleDetailId)
        {
            List<Attendance> attendances = _projectContext.Attendances.Include(c => c.User).Where(c => c.ScheduleDetailId == scheduleDetailId).ToList();
            return attendances;
        }

        public void UpdateClassAttendance(int attendanceId, bool status)
        {
            Attendance attendances = _projectContext.Attendances.FirstOrDefault(c => c.AttendanceId == attendanceId);
            attendances.Attendance1 = status;
            _projectContext.SaveChanges();
        }
    }
}
