using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerApp.Data;

namespace ServerApp.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]
   
    public class LogController : ControllerBase
    {
        private readonly SocialContext _context;
        public LogController(SocialContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var logs = await _context.Log.ToListAsync();
            return Ok(logs);
        }
    }
}