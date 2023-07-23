using Microsoft.EntityFrameworkCore;
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

        public User GetTeacher(string group, string courseName)
        {
            Schedule Schedule = context.Schedules.Include(c => c.Class).ThenInclude(c => c.ClassDetails).Include(c => c.Course).FirstOrDefault(c => c.Course.CourseName.Equals(courseName) && c.Class.ClassName.Equals(group));
            foreach (var item in Schedule.Class.ClassDetails)
            {
                User user = context.Users.FirstOrDefault(c => c.UserId == item.UserId && c.Role.Equals("teacher"));
                if (user != null)
                {
                    return user;
                }
            }
            return null;
        }
    }
}
