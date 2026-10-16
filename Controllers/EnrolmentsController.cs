using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDayAPI.Data;
using RaceDayAPI.Models;

namespace RaceDayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrolmentsController : ControllerBase
    {
        private readonly RaceDayDbContext _context;

        public EnrolmentsController(RaceDayDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Enrol([FromBody] Enrolment enrolment)
        {
            var role = HttpContext.Session.GetString("UserRole");
            var userId = HttpContext.Session.GetInt32("UserID");

            if (role != "Participant" || userId == null)
                return Unauthorized(new { message = "Only authenticated Participants can enrol in events." }); 

            enrolment.ParticipantID = userId.Value;
            _context.Enrolments.Add(enrolment);
            await _context.SaveChangesAsync();
            return Ok(enrolment);
        }
    }
}