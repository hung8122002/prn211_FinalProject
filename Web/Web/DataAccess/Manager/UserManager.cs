using Web.DataAccess.Models;

namespace Web.DataAccess.Manager
{
    public class UserManager
    {
        PRN211_FinalProjectContext context;

        public UserManager(PRN211_FinalProjectContext context)
        {
            this.context = context;
        }

        public User GetUser(string username, string password)
        {
            User user = context.Users.FirstOrDefault(c => c.UserName.Equals(username) && c.Password.Equals(password));
            return user;
        }

        public User GetUserByUsername(string username)
        {
            User user = context.Users.FirstOrDefault(c => c.UserName.Equals(username));
            return user;
        }
    }
}
