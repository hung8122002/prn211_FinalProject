using AutoMapper;
using Web.Bussiness.DTO;
using Web.DataAccess.Models;

namespace Web.Bussiness.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<Schedule, ScheduleDTO>();
            CreateMap<Class, ClassDTO>();
            CreateMap<ClassDetail, ClassDetailDTO>();
            CreateMap<Course, CourseDTO>();
            CreateMap<Room, RoomDTO>();
        }
    }
}
