
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ModelLayer;
using Repository_Layer;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginApiController : ControllerBase
    {
        private readonly AppDBcontext _dataContext;
        private readonly IConfiguration _config;
        public LoginApiController(AppDBcontext dataContext,IConfiguration configuration)
        {
            _dataContext = dataContext;
            _config = configuration;

        }
        public static AdminVerify verify = new AdminVerify();

        [HttpPost("register")]
        public async Task<IActionResult> Register(AdminLogin request)
        {
            if (_dataContext.VerifyDetails.Any(u => u.UserName == request.Username))
            {
                return BadRequest("User already exist");
            }
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new AdminVerify
            {
                UserName = request.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,               
            };
            _dataContext.VerifyDetails.Add(user);
            await _dataContext.SaveChangesAsync();
            return Ok("user Succesfully created");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(AdminLogin request)
        {

            var user = await _dataContext.VerifyDetails.FirstOrDefaultAsync(u => u.UserName == request.Username);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Password is Incorrect");
            }


            string token = CreateToken(user);
            return Ok(token);


        }
        private string CreateToken(AdminVerify user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }


        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.
                    ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.
                    ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);

            }
        }

    }
}
