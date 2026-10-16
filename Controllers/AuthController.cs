using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDayAPI.Data;
using RaceDayAPI.DTOs;
using RaceDayAPI.Models;

namespace RaceDayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly RaceDayDbContext _context;

        public AuthController(RaceDayDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            if (dto.Role.Equals("Organiser", StringComparison.OrdinalIgnoreCase))
            {
                if (await _context.Organisers.AnyAsync(o => o.Email == dto.Email))
                    return BadRequest(new { message = "Email already exists." });

                var org = new Organiser { FirstName = dto.FirstName, LastName = dto.LastName, Email = dto.Email, PasswordHash = passwordHash };
                _context.Organisers.Add(org);
            }
            else if (dto.Role.Equals("Participant", StringComparison.OrdinalIgnoreCase))
            {
                if (await _context.Participants.AnyAsync(p => p.Email == dto.Email))
                    return BadRequest(new { message = "Email already exists." });

                var part = new Participant { FirstName = dto.FirstName, LastName = dto.LastName, Email = dto.Email, PasswordHash = passwordHash };
                _context.Participants.Add(part);
            }
            else
            {
                return BadRequest(new { message = "Invalid role. Select 'Organiser' or 'Participant'." });
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Registration successful." });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (dto.Role.Equals("Organiser", StringComparison.OrdinalIgnoreCase))
            {
                var org = await _context.Organisers.FirstOrDefaultAsync(o => o.Email == dto.Email);
                if (org == null || !BCrypt.Net.BCrypt.Verify(dto.Password, org.PasswordHash))
                    return Unauthorized(new { message = "Invalid credentials." });

                HttpContext.Session.SetInt32("UserID", org.OrganiserID);
                HttpContext.Session.SetString("UserRole", "Organiser");
                return Ok(new { message = "Logged in successfully as Organiser." });
            }
            else if (dto.Role.Equals("Participant", StringComparison.OrdinalIgnoreCase))
            {
                var part = await _context.Participants.FirstOrDefaultAsync(p => p.Email == dto.Email);
                if (part == null || !BCrypt.Net.BCrypt.Verify(dto.Password, part.PasswordHash))
                    return Unauthorized(new { message = "Invalid credentials." });

                HttpContext.Session.SetInt32("UserID", part.ParticipantID);
                HttpContext.Session.SetString("UserRole", "Participant");
                return Ok(new { message = "Logged in successfully as Participant." });
            }

            return BadRequest(new { message = "Invalid role." });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Ok(new { message = "Logged out successfully." });
        }
    }
}
