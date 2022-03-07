using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerApp.Models
{
    public class Tasinmaz
    {
        [Key]
        public int TasinmazId { get; set; }
        public int Ada { get; set; }
        public int Parsel { get; set; }
        public string Nitelik { get; set; }
        public string Adres { get; set; }
        public bool Is_active { get; set; }    

        [ForeignKey("Mahalle")]
        public int MahalleId { get; set; }
        public virtual Mahalle Mahalle { get; set; }
    }
}