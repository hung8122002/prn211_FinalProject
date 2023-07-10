using Web.Bussiness.DTO;

namespace Web.Bussiness.IRepository
{
    public interface IUserRepository
    {
        public UserDTO GetUser(string username, string password);
        public UserDTO GetUserByUsername(string username);
    }
}
