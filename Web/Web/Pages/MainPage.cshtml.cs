using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using Web.DataAccess.Models;
using Web.Bussiness.IRepository;
using Web.Bussiness.DTO;

namespace Web.Pages
{
    public class MainPageModel : PageModel
    {
        private readonly IUserRepository userRepository;
        private readonly IScheduleRepository scheduleRepository;
        public string role { get; set; }

        public MainPageModel(IUserRepository userRepository, IScheduleRepository scheduleRepository)
        {
            this.userRepository = userRepository;
            this.scheduleRepository = scheduleRepository;
        }

        public void OnGet()
        {
            role = HttpContext.Session.GetString("role");
        }

        public IActionResult OnGetData(string startDate, string endDate)
        {
            UserDTO user = userRepository.GetUserByUsername(HttpContext.Session.GetString("username"));
            role = HttpContext.Session.GetString("role");
            List<AttendanceDTO> scheduleDetailDTOs = scheduleRepository.GetScheduleDetails(user.UserId, DateTime.Parse(startDate), DateTime.Parse(endDate));
            var result = new { scheduleDetailDTOs };
            return new JsonResult(result);
        }

        public IActionResult OnGetTeacher(string group, string courseName)
        {
            UserDTO userDTO = userRepository.GetTeacher(group, courseName);
            role = HttpContext.Session.GetString("role");
            var result = new { userDTO };
            return new JsonResult(result);
        }
    }
}
