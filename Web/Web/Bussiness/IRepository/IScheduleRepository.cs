using Web.Bussiness.DTO;
using Web.DataAccess.Models;

namespace Web.Bussiness.IRepository
{
    public interface IScheduleRepository
    {
        public List<AttendanceDTO> GetScheduleDetails(int userId, DateTime startDate, DateTime endDate);
    }
}
