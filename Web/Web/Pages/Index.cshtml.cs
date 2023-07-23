using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Bussiness.DTO;
using Web.Bussiness.IRepository;
using Web.DataAccess.Models;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        public IndexModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost(string username, string password)
        {
            UserDTO userDTO = _userRepository.GetUser(username, password);
            if (userDTO == null)
            {
                return RedirectToPage();
            }
            HttpContext.Session.SetString("username", userDTO.UserName);
            HttpContext.Session.SetString("role", userDTO.Role);
            return RedirectToPage("/MainPage");
        }
    }
}