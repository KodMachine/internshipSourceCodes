using Microsoft.EntityFrameworkCore;
using ServerApp.Models;

namespace ServerApp.Data
{
    public class SocialContext: DbContext
    {
        public SocialContext(DbContextOptions<SocialContext> options):base(options)
        {
            
        }
         public DbSet<Il> Il { get; set; }
         public DbSet<Ilce> Ilce { get; set; }
         public DbSet<Mahalle> Mahalle { get; set; }
         public DbSet<Tasinmaz> Tasinmaz { get; set; }
         public DbSet<Kullanici> Kullanici { get; set; }
         public DbSet<Log> Log { get; set; }
         
    }
}