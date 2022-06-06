using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.Data
{
    public  class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Required]
        [MaxLength(15)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(50)]
        public string PersonalNumber { get; set; }
        [Required]
        [MaxLength(11)]
        List<LogTime> LogTime { get; set; } = new List<LogTime>();
        List<Card> Card { get; set; } = new List<Card>();
    }
}
