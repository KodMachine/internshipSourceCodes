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

    public class IlceController : ControllerBase
    {
        private readonly SocialContext _context;
        public IlceController(SocialContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var ilces = await _context.Ilce.ToListAsync();
            return Ok(ilces);
        }
        
        [HttpGet("{IlId}")]
        public async Task<ActionResult> GetIlce(int IlId)
        {
            var ilces = await _context.Ilce.Where(x=> x.IlId == IlId).ToListAsync();;
            return Ok(ilces);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Ilce ilce)
        {
            var result = _context.Ilce.FirstOrDefault(e => e.IlceName.Equals(ilce.IlceName)
                                                        && e.IlId.Equals(ilce.IlceId));
            if(result != null)
            {
                return BadRequest();
            }
            else
            {
                _context.Ilce.Add(ilce);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new{id = ilce.IlceId}, ilce);
            }
        }
    }
}