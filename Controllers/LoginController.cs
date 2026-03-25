

using AgriIntel_Advisory_System.Interface;
using AgriIntel_Advisory_System.Services;
using AgriIntel_Advisory_System.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AgriIntel_Advisory_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginApiService _service;
        private readonly IConfiguration _configuration;

        public LoginController(LoginApiService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        /* ================= FARMER LOGIN ================= */

        [HttpPost("farmer")]
        public async Task<IActionResult> FarmerLogin(LoginVM model)
        {
            var user = await _service.FarmerLogin(model.Identifier, model.Password);

            if (user == null)
                return Unauthorized("Invalid Credentials");

            var token = GenerateToken(user.FarmerId.ToString(), "Farmer");

            return Ok(new
            {
                token,
                user
            });
        }

        /* ================= EXPERT LOGIN ================= */

        [HttpPost("expert")]
        public async Task<IActionResult> ExpertLogin(LoginVM model)
        {
            var user = await _service.ExpertLogin(model.Identifier, model.Password);

            if (user == null)
                return Unauthorized("Invalid Credentials");

            var token = GenerateToken(user.ExpertId.ToString(), "Expert");

            return Ok(new
            {
                token,
                user
            });
        }

        /* ================= STAFF LOGIN ================= */

        [HttpPost("staff")]
        public async Task<IActionResult> StaffLogin(LoginVM model)
        {
            var user = await _service.StaffLogin(model.Identifier, model.Password);

            if (user == null)
                return Unauthorized("Invalid Credentials");

            var token = GenerateToken(user.EmpId.ToString(), "Staff");

            return Ok(new
            {
                token,
                user
            });
        }

        /* ================= KISAN KENDRA LOGIN ================= */

        [HttpPost("kendra")]
        public async Task<IActionResult> KendraLogin(LoginVM model)
        {
            var user = await _service.KendraLogin(model.Identifier, model.Password);

            if (user == null)
                return Unauthorized("Invalid Credentials");

            var token = GenerateToken(user.KKId.ToString(), "Kendra");

            return Ok(new
            {
                token,
                user
            });
        }

        /* ================= JWT TOKEN GENERATOR ================= */

        private string GenerateToken(string id, string role)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, id),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!)
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}




