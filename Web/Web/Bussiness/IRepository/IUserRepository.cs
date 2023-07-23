using Web.Bussiness.DTO;
using Web.DataAccess.Models;

namespace Web.Bussiness.IRepository
{
    public interface IUserRepository
    {
        public UserDTO GetUser(string username, string password);
        public UserDTO GetUserByUsername(string username);
        public UserDTO GetTeacher(string group, string courseName);
    }
}
