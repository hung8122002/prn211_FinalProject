using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Web.Bussiness.DTO;
using Web.Bussiness.IRepository;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        public IndexModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public void OnGet()
        {

        }

        public IActionResult OnPost(string username, string password, [FromServices] IConfiguration configuration)
        {
            UserDTO userDTO = _userRepository.GetUser(username, password);

            if (userDTO == null)
            {
                return RedirectToPage();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = configuration["Jwt:SecretKey"];
            var keyBytes = Encoding.UTF8.GetBytes(secretKey);
            var key = new SymmetricSecurityKey(keyBytes);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, userDTO.UserName),
            new Claim(ClaimTypes.Role, userDTO.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            HttpContext.Session.SetString("jwt", tokenString);

            return RedirectToPage("/MainPage");
        }
    }
}