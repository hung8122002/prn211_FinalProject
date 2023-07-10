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

        public ScheduleRepository(PRN211_FinalProjectContext projectContext, IMapper mapper)
        {
            _projectContext = projectContext;
            _mapper = mapper;
        }

        public List<ScheduleDTO> GetScheduleDetails(int userId, DateTime startDate, DateTime endDate)
        {
            ScheduleManager scheduleManager = new(_projectContext);
            List<Schedule> scheduleDetails = scheduleManager.GetScheduleDetails(userId, startDate, endDate);
            List<ScheduleDTO> scheduleDetailDTOs = _mapper.Map<List<ScheduleDTO>>(scheduleDetails);
            return scheduleDetailDTOs;
        }
    }
}
