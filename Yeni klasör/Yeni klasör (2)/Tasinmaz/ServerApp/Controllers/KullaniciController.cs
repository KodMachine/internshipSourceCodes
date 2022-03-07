using System;
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
    [Route ("api/[controller]")]
    public class KullaniciController:ControllerBase
    {
        private readonly SocialContext _context;
        
        public KullaniciController(SocialContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Obsolete]
        public async Task<ActionResult> Get()
        { 
            var kullaniciInclude = await _context.Kullanici
            .Select(x => new {
                KullaniciId = x.KullaniciId,
                isActive = x.isActive,
                KullaniciName = x.KullaniciName,
                kullaniciSurname = x.KullaniciSurname,
                Mail = x.Mail,
                Rol = x.Rol,
                Address = x.Address,
            }).Where(x => x.isActive).ToListAsync();

            _context.Log.Add(Methods.newLog("Kullanıcılar ", "Kullanıcılar get", true));
            await _context.SaveChangesAsync();
            return Ok(kullaniciInclude);
        }

        [HttpPost("Paged")]
        [Obsolete]
        public async Task<ActionResult> GetPaged(PageInfo paged)
        { 
            var dataPerPage = 2;
            if(paged.Filter == null || paged.Filter.Equals("filtresiz"))
            {
                var kullaniciInclude = await _context.Kullanici
                .Select(x => new {
                    KullaniciId = x.KullaniciId,
                    isActive = x.isActive,
                    KullaniciName = x.KullaniciName,
                    kullaniciSurname = x.KullaniciSurname,
                    Mail = x.Mail,
                    Rol = x.Rol,
                    Address = x.Address,
                }).Where(x => x.isActive).Skip((paged.PageNumber-1) * dataPerPage).Take(dataPerPage).ToListAsync();

                _context.Log.Add(Methods.newLog("Kullanıcılar ", "Kullanıcılar get filtresiz", true));
                await _context.SaveChangesAsync();
                return Ok(kullaniciInclude);
            }
            else
            {
                if(paged.Filter.ToLower().Equals("admin"))
                    paged.Filter = "true";
                else  if(paged.Filter.ToLower().Equals("kullanıcı"))
                    paged.Filter = "false";
                var kullaniciInclude = await _context.Kullanici
                .Select(x => new {
                    KullaniciId = x.KullaniciId,
                    isActive = x.isActive,
                    KullaniciName = x.KullaniciName,
                    kullaniciSurname = x.KullaniciSurname,
                    Mail = x.Mail,
                    Rol = x.Rol,
                    Address = x.Address,
                }).Where(x => x.isActive
                        && (x.KullaniciName.ToLower().Contains(paged.Filter.ToLower())
                            ||x.kullaniciSurname.ToLower().Contains(paged.Filter.ToLower())
                            ||x.Mail.ToLower().Contains(paged.Filter.ToString())
                            ||x.Address.ToLower().Contains(paged.Filter.ToString())
                            ||x.Rol.ToString().ToLower().Equals(paged.Filter))
                ).Skip((paged.PageNumber-1) * dataPerPage).Take(dataPerPage).ToListAsync();

                _context.Log.Add(Methods.newLog("Kullanıcılar ", "Kullanıcılar get filtreli", true));
                await _context.SaveChangesAsync();
                return Ok(kullaniciInclude);
            }
        }

        [HttpGet("{id}")]
        [Obsolete]
        public async Task<IActionResult> GetKullanici(int id)
        {
            var tmpKullanici = await _context.Kullanici.FirstOrDefaultAsync( i => i.KullaniciId == id);
            if( tmpKullanici == null)
            {
                _context.Log.Add(Methods.newLog("Kullanıcı isteme", "Kullanıcı get", false));
                await _context.SaveChangesAsync();
                return NotFound();
            }

            _context.Log.Add(Methods.newLog("Kullanıcı isteme", "Kullanıcı get", true));
            await _context.SaveChangesAsync();
            return Ok(tmpKullanici);
        }

        [HttpPost]
        [Obsolete]
        public async Task<IActionResult> Post(Kullanici kullanici)
        {
            var result = _context.Kullanici.FirstOrDefault(e => e.isActive.Equals(kullanici.isActive) 
                                       && e.KullaniciName.Equals(kullanici.KullaniciName)
                                       && e.KullaniciSurname.Equals(kullanici.KullaniciSurname)
                                       && e.Mail.Equals(kullanici.Mail)
                                       && e.Password.Equals(kullanici.Password)
                                       && e.Rol.Equals(kullanici.Rol)
                                       && e.Address.Equals(kullanici.Address));
            
            if(result != null)
            {
                _context.Log.Add(Methods.newLog("Yeni kullanıcı ekleme", "Kullanıcı post", false));
                await _context.SaveChangesAsync();
                
                return BadRequest();
            }
            else
            {
                kullanici.isActive = true;
                kullanici.Password = Methods.Sha256(kullanici.Password);
                _context.Kullanici.Add(kullanici);
                _context.Log.Add(Methods.newLog("Yeni kullanıcı ekleme", "Kullanıcı post", true));
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new{id = kullanici.KullaniciId}, kullanici);
            }
        }

        [HttpPut("{id}")]
        [Obsolete]
        public async Task<IActionResult> Update(int id, Kullanici kullanici)
        {
            if(id != kullanici.KullaniciId)
            {
                _context.Log.Add(Methods.newLog("Kullanıcı güncelleme", "Kullanıcı put", false));
                await _context.SaveChangesAsync();
                return BadRequest();
            }
            
            var tmpKullanici = await _context.Kullanici.FindAsync(id);
            
            if(tmpKullanici == null)
            {
                _context.Log.Add(Methods.newLog("Kullanıcı güncelleme", "Kullanıcı put", false));
                await _context.SaveChangesAsync();
                return NotFound();
            }

            tmpKullanici.KullaniciName = kullanici.KullaniciName;
            tmpKullanici.KullaniciSurname = kullanici.KullaniciSurname;
            tmpKullanici.Mail = kullanici.Mail;
            tmpKullanici.Password = kullanici.Password;
            tmpKullanici.Rol = kullanici.Rol;

            _context.Log.Add(Methods.newLog("Kullanıcı güncelleme", "Kullanıcı put", true));

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
            var kullanici = await _context.Kullanici.FindAsync(id);

            if(kullanici == null)
            {
                _context.Log.Add(Methods.newLog("Kullanıcı silme", "Kullanıcı delete", false));
                await _context.SaveChangesAsync();
                return NotFound();
            }

            kullanici.isActive = false;
            _context.Log.Add(Methods.newLog("Kullanıcı silme", "Kullanıcı delete", true));
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("Login")]
        [Obsolete]
        public async Task<IActionResult> PostLogin(Login login)
        {
            var result = _context.Kullanici.FirstOrDefault(e => e.Mail.Equals(login.Mail)
                                       && e.Password.Equals(login.Password));
            
            if(result == null)
            {
                _context.Log.Add(Methods.newLog("Giriş-"+login.Mail, "Giriş post", false));
                await _context.SaveChangesAsync();
                return BadRequest();
            }

            _context.Log.Add(Methods.newLog("Giriş-"+login.Mail, "Giriş post", true));
            await _context.SaveChangesAsync();
            return Ok(new {
                kullaniciId = result.KullaniciId,
                kullaniciName = result.KullaniciName,
                kullaniciSurname = result.KullaniciSurname,
                mail = result.Mail,
                rol = result.Rol,
                address = result.Address
            });
        }
        
    }
}