using Microsoft.EntityFrameworkCore;
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

        public List<Schedule> GetScheduleDetails(int userId, DateTime startDate, DateTime endDate)
        {
            return _projectContext.ClassDetails
                .Where(c => c.UserId == userId)
                .SelectMany(classDetail => _projectContext.Schedules
                    .Include(s => s.Class)
                    .Include(s => s.Room)
                    .Include(s => s.Course)
                    .Where(s => s.ClassId == classDetail.ClassId && s.Date >= startDate && s.Date <= endDate))
                .OrderBy(s => s.Date) // sắp xếp thời gian tăng dần
                .ToList();
        }
    }
}
