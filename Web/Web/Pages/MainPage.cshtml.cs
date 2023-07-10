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
    public class MainPageModel : PageModel
    {
        private readonly IScheduleRepository _scheduleDetailRepository;
        private readonly IUserRepository _userRepository;

        public MainPageModel(IScheduleRepository scheduleDetailRepository, IUserRepository userRepository)
        {
            _scheduleDetailRepository = scheduleDetailRepository;
            _userRepository = userRepository;
        }

        public void OnGet()
        {

        }

        public JsonResult OnGetData([FromServices] IConfiguration configuration, DateTime startDate, DateTime endDate)
        {
            var jwt = HttpContext.Session.GetString("jwt");

            // Decode the JWT and extract the claims
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = configuration["Jwt:SecretKey"];
            var keyBytes = Encoding.UTF8.GetBytes(secretKey);
            var key = new SymmetricSecurityKey(keyBytes);
            try
            {
                tokenHandler.ValidateToken(jwt, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false
                }, out SecurityToken validatedToken);

                // Get the JWT claims
                var claims = (validatedToken as JwtSecurityToken).Claims;
                // Use the claims to authenticate the user
                string username = claims.FirstOrDefault(c => c.Type == "name").Value;
                //UserDTO userDTO = _userRepository.GetUserByUsername(username);
                List<ScheduleDTO> scheduleDetailDTOs = _scheduleDetailRepository.GetScheduleDetails(1, startDate, endDate);
                var result = new { scheduleDetailDTOs };
                return new JsonResult(result);
            }
            catch (SecurityTokenException)
            {
                // The token is not valid
                // Handle the error
                return null;
            }
        }
    }
}
