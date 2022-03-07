using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServerApp.Models
{
    public class Il
    {
        [Key]
        public int IlId { get; set; }
        public string IlName { get; set; }
    }
}