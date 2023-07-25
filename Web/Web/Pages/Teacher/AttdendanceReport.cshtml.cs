using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Text.Json;
using Web.Bussiness.DTO;
using Web.Bussiness.IRepository;
using Web.DataAccess.Models;

namespace Web.Pages.Teacher
{
    public class AttdendanceReportModel : PageModel
    {
        public class Item
        {
            public string id { get; set; }
            public bool status { get; set; }
        }

        private readonly IUserRepository _userRepository;
        private readonly IScheduleRepository _scheduleRepository;

        public AttdendanceReportModel(IUserRepository userRepository, IScheduleRepository scheduleRepository)
        {
            _userRepository = userRepository;
            _scheduleRepository = scheduleRepository;
        }

        public List<ScheduleDetailDTO> scheduleDetailDTOs { get; set; }
        public string role { get; set; }
        public List<AttendanceDTO> attendanceDTOs { get; set; }
        public IActionResult OnGet()
        {
            if (!HttpContext.Session.GetString("role").Equals("teacher"))
            {
                return RedirectToPage("/Index");
            }
            role = HttpContext.Session.GetString("role");
            return Page();
        }

        public void OnGetDate(string date)
        {
            UserDTO user = _userRepository.GetUserByUsername(HttpContext.Session.GetString("username"));
            HttpContext.Session.SetString("date", date);
            role = HttpContext.Session.GetString("role");
            scheduleDetailDTOs = _scheduleRepository.GetTeacherSchedule(user.UserId, DateTime.Parse(date));
        }

        public void OnGetData(string data)
        {
            List<Item> itemList = JsonSerializer.Deserialize<List<Item>>(data);
            foreach (var item in itemList)
            {
                _scheduleRepository.UpdateClassAttendance(Int32.Parse(item.id), item.status);
            }
            UserDTO user = _userRepository.GetUserByUsername(HttpContext.Session.GetString("username"));
            role = HttpContext.Session.GetString("role");
            scheduleDetailDTOs = _scheduleRepository.GetTeacherSchedule(user.UserId, DateTime.Parse(HttpContext.Session.GetString("date")));
        }

        public void OnGetAttendance(int scheduleDetailId)
        {
            UserDTO user = _userRepository.GetUserByUsername(HttpContext.Session.GetString("username"));
            role = HttpContext.Session.GetString("role");
            scheduleDetailDTOs = _scheduleRepository.GetTeacherSchedule(user.UserId, DateTime.Parse(HttpContext.Session.GetString("date")));
            attendanceDTOs = _scheduleRepository.GetClassAttendances(scheduleDetailId);
        }
    }
}
