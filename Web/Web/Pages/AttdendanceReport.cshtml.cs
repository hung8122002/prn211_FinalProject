using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Bussiness.DTO;
using Web.Bussiness.IRepository;
using Web.Bussiness.Repository;
using Web.DataAccess.Models;

namespace Web.Pages
{
    public class AttdendanceReportModel : PageModel
    {
        private readonly IUserRepository _userRepository;
        private readonly IScheduleRepository _scheduleRepository;

        public AttdendanceReportModel(IUserRepository userRepository, IScheduleRepository scheduleRepository)
        {
            _userRepository = userRepository;
            _scheduleRepository = scheduleRepository;
        }
        public string role { get; set; }
        public List<SemesterDTO> semesterDTOs = new List<SemesterDTO>();
        public List<ScheduleDTO> courses = new List<ScheduleDTO>();
        public List<AttendanceDTO> attendanceDTOs = new List<AttendanceDTO>();
        public IActionResult OnGet()
        {
            if(!HttpContext.Session.GetString("role").Equals("student"))
            {
                return RedirectToPage("/Index");
            }
            UserDTO user = _userRepository.GetUserByUsername(HttpContext.Session.GetString("username"));
            role = HttpContext.Session.GetString("role");
            semesterDTOs = _scheduleRepository.GetSemester();
            return Page();
        }

        public void OnGetCourses(int year, int semesterId)
        {
            UserDTO user = _userRepository.GetUserByUsername(HttpContext.Session.GetString("username"));
            role = HttpContext.Session.GetString("role");
            semesterDTOs = _scheduleRepository.GetSemester();
            HttpContext.Session.SetInt32("year", year);
            HttpContext.Session.SetInt32("semesterId", semesterId);
            courses = _scheduleRepository.GetSchedulesBySemester(user.UserId, semesterId, year);
        }

        public void OnGetAttendance(int scheduleId, string test)
        {
            UserDTO user = _userRepository.GetUserByUsername(HttpContext.Session.GetString("username"));
            role = HttpContext.Session.GetString("role");
            attendanceDTOs = _scheduleRepository.GetAttendance(user.UserId, scheduleId);
            semesterDTOs = _scheduleRepository.GetSemester();
            courses = _scheduleRepository.GetSchedulesBySemester(user.UserId, HttpContext.Session.GetInt32("semesterId").Value, HttpContext.Session.GetInt32("year").Value);
        }
    }
}
