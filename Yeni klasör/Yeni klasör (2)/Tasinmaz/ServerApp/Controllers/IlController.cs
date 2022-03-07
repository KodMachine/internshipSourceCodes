using System.Collections.Generic;
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
    public class IlController : ControllerBase
    {
        private readonly SocialContext _context;
        public IlController(SocialContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var ils = await _context.Il.ToListAsync();
            return Ok(ils);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Il il)
        {
            var result = _context.Il.FirstOrDefault(e => e.IlName.Equals(il.IlName));
            if(result != null)
            {
                return BadRequest();
            }
            else
            {
                _context.Il.Add(il);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new{id = il.IlId}, il);
            }
        }
    }
}