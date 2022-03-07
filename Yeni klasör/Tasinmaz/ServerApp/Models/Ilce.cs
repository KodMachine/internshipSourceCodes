using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerApp.Models
{
    public class Ilce
    {
        [Key]
        public int IlceId { get; set; }
        public string IlceName { get; set; }
        
        [ForeignKey("Il")]
        public int IlId { get; set; }
        public virtual Il Il { get; set; }
    }
}