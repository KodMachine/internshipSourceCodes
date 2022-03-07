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
        
        [HttpPost("paged")]
        public async Task<ActionResult> GetPaged(PageInfo paged)
        { 
            var dataPerPage = 10; 
            if(paged.Filter == null || paged.Filter.Equals("filtresiz"))
            {
                var logs = await _context.Log.Skip((paged.PageNumber-1) * dataPerPage).Take(dataPerPage).ToListAsync();
                return Ok(logs);
            }
            else
            {
                if(paged.Filter.ToLower().Equals("başarılı"))
                    paged.Filter = "true";
                else  if(paged.Filter.ToLower().Equals("başarısız"))
                    paged.Filter = "false";
                var logs = await _context.Log.Where(x => x.Detail.ToLower().Contains(paged.Filter.ToLower())
                                                    || x.Explanation.ToLower().Contains(paged.Filter.ToLower())
                                                    || x.Ip.ToLower().Contains(paged.Filter.ToLower())                                    
                                                    || x.DateHour.ToString().ToLower().Contains(paged.Filter.ToLower())
                                                    || x.ProccesSuccess.ToString().ToLower().Contains(paged.Filter.ToLower())
                                                    )
                .Skip((paged.PageNumber-1) * dataPerPage).Take(dataPerPage).ToListAsync();

                return Ok(logs);
            }
        }
        
    }
    
}