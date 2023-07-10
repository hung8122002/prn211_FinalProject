using Web.Bussiness.DTO;

namespace Web.Bussiness.IRepository
{
    public interface IScheduleRepository
    {
        public List<ScheduleDTO> GetScheduleDetails(int userId, DateTime startDate, DateTime endDate);
    }
}
