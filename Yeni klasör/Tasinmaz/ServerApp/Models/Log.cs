using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace ServerApp.Models
{
    public class Log
    {
        [Key]
        public int LogId { get; set; }
        public bool ProccesSuccess { get; set; }
        public string Detail { get; set; }
        public string Ip { get; set; }
        public DateTime DateHour { get; set; }
        public string Explanation { get; set; }

    }
}