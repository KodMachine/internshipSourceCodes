using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServerApp.Models
{
    public class Kullanici
    {
        [Key]
        public int KullaniciId { get; set; }
        public bool isActive { get; set; }
        public string KullaniciName { get; set; }
        public string KullaniciSurname { get; set; }
        public string Mail { get; set; }
        public bool Rol { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
    }
}