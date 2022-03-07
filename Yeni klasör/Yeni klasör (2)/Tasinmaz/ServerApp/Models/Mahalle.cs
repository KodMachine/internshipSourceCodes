using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerApp.Models
{
    public class Mahalle
    {
        [Key]
        public int MahalleId { get; set; }
        public string MahalleName { get; set; }
        
        [ForeignKey("Ilce")]
        public int IlceId { get; set; }
        public virtual Ilce Ilce { get; set;}
    }
}