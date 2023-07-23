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

        public List<AttendanceDTO> GetScheduleDetails(int userId, DateTime startDate, DateTime endDate)
        {
            List<Attendance> scheduleDetails = scheduleManager.GetScheduleDetails(userId, startDate, endDate);
            List<AttendanceDTO> scheduleDetailDTOs = _mapper.Map<List<AttendanceDTO>>(scheduleDetails);
            return scheduleDetailDTOs;
        }
    }
}
