using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerApp.Data;
using ServerApp.Models;

namespace ServerApp.Controllers
{ 
    [ApiController]
    [Route("api/[controller]")]

    public class MahalleController : ControllerBase
    {
        private readonly SocialContext _context;
        public MahalleController(SocialContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var mahalles = await _context.Mahalle.ToListAsync();
            return Ok(mahalles);
        }
        
        [HttpGet("{IlceId}")]
        public async Task<ActionResult> GetIlce(int IlceId)
        {
            var mahalles = await _context.Mahalle.Where(x=> x.IlceId == IlceId).ToListAsync();
            return Ok(mahalles);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Mahalle mahalle)
        {
            var result = _context.Mahalle.FirstOrDefault(e => e.MahalleName.Equals(mahalle.MahalleName)
                                                        && e.IlceId.Equals(mahalle.IlceId));
            if(result != null)
            {
                return BadRequest();
            }
            else
            {
                _context.Mahalle.Add(mahalle);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new{id = mahalle.MahalleId}, mahalle);
            }
        }

    }
}