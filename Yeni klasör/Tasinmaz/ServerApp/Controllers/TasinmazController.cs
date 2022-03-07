using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerApp.Data;
using ServerApp.Models;

namespace ServerApp.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]
   
    public class TasinmazController : ControllerBase
    {        
        private readonly SocialContext _context;
        public TasinmazController(SocialContext context)
        {
            _context = context;
        }

        [HttpGet]
        [System.Obsolete]
        public async Task<ActionResult> Get()
        {
            var tasinmazs = await _context.Tasinmaz.Where(x=> x.Is_active).ToListAsync();
            _context.Log.Add(Methods.newLog("Taşınmazlar ", "Taşınmazlar get", true));
            await _context.SaveChangesAsync();
            return Ok(tasinmazs);
        }

        [HttpPost]
        [Obsolete]
        public async Task<IActionResult> Post(Tasinmaz tasinmaz)
        {
            var result = _context.Tasinmaz.FirstOrDefault(e => e.Ada.Equals(tasinmaz.Ada) 
                                       && e.Parsel.Equals(tasinmaz.Parsel)
                                       && e.Nitelik.Equals(tasinmaz.Nitelik)
                                       && e.Adres.Equals(tasinmaz.Adres)
                                       && e.Is_active.Equals(tasinmaz.Is_active)
                                       && e.MahalleId.Equals(tasinmaz.MahalleId));
            
            if(result != null)
            {
                _context.Log.Add(Methods.newLog("Yeni taşınmaz ekleme", "Taşınmaz post", false));
                await _context.SaveChangesAsync();
                
                return BadRequest();
            }
            else
            {
                tasinmaz.Is_active=true;
                _context.Tasinmaz.Add(tasinmaz);
                _context.Log.Add(Methods.newLog("Yeni taşınmaz ekleme", "Taşınmaz post", true));
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new{id = tasinmaz.TasinmazId}, tasinmaz);
            }
        }

        [HttpPut("{id}")]
        [Obsolete]
        public async Task<IActionResult> Update(int id, Tasinmaz tasinmaz)
        {
            if(id != tasinmaz.TasinmazId)
            {
                _context.Log.Add(Methods.newLog("Taşınmaz güncelleme", "Taşınmaz put", false));
                await _context.SaveChangesAsync();
                return BadRequest();
            }
            
            var tasinmazs = await _context.Tasinmaz.FindAsync(id);
            
            if(tasinmazs == null)
            {
                _context.Log.Add(Methods.newLog("Taşınmaz güncelleme", "Taşınmaz put", false));
                await _context.SaveChangesAsync();
                return NotFound();
            }

            tasinmazs.Ada = tasinmaz.Ada;
            tasinmazs.Parsel = tasinmaz.Parsel;
            tasinmazs.Nitelik = tasinmaz.Nitelik;
            tasinmazs.Adres = tasinmaz.Adres;
            tasinmazs.Is_active = tasinmaz.Is_active;
            tasinmazs.MahalleId = tasinmaz.MahalleId;

            _context.Log.Add(Methods.newLog("Taşınmaz güncelleme", "Taşınmaz put", true));

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
            return NoContent();
        }



        
        [HttpDelete("{id}")]
        [Obsolete]
        public async Task<IActionResult> Delete(int id)
        {
            var tasinmaz = await _context.Tasinmaz.FindAsync(id);

            if(tasinmaz == null)
            {
                _context.Log.Add(Methods.newLog("Taşınmaz silme", "Taşınmaz delete", false));
                await _context.SaveChangesAsync();
                return NotFound();
            }

            tasinmaz.Is_active = false;
            _context.Log.Add(Methods.newLog("Taşınmaz silme", "Taşınmaz delete", true));
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}