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

        public UserRepository(PRN211_FinalProjectContext projectContext, IMapper mapper)
        {
            _projectContext = projectContext;
            _mapper = mapper;
        }

        public UserDTO GetUser(string username, string password)
        {
            UserManager userManager = new(_projectContext);
            User user = userManager.GetUser(username, password);
            UserDTO userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public UserDTO GetUserByUsername(string username)
        {
            UserManager userManager = new(_projectContext);
            User user = userManager.GetUserByUsername(username);
            UserDTO userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }
    }
}
