using AutoMapper;
using Web.Bussiness.DTO;
using Web.Bussiness.IRepository;
using Web.DataAccess.Manager;
using Web.DataAccess.Models;

namespace Web.Bussiness.Repository
{
    public class UserRepository : IUserRepository
    {
        PRN211_FinalProjectContext _projectContext;
        IMapper _mapper;
        UserManager userManager;

        public UserRepository(PRN211_FinalProjectContext projectContext, IMapper mapper)
        {
            _projectContext = projectContext;
            _mapper = mapper;
            userManager = new(_projectContext);
        }

        public UserDTO GetTeacher(string group, string courseName)
        {
            User user = userManager.GetTeacher(group, courseName);
            UserDTO userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public UserDTO GetUser(string username, string password)
        {
            User user = userManager.GetUser(username, password);
            UserDTO userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public UserDTO GetUserByUsername(string username)
        {
            User user = userManager.GetUserByUsername(username);
            UserDTO userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }
    }
}
