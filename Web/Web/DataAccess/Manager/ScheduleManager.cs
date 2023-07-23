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
    }
}
