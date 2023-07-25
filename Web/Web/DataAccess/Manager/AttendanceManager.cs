using Web.DataAccess.Models;

namespace Web.DataAccess.Manager
{
    public class AttendanceManager
    {
        PRN211_FinalProjectContext _projectContext;

        public AttendanceManager(PRN211_FinalProjectContext projectContext)
        {
            _projectContext = projectContext;
        }
    }
}
