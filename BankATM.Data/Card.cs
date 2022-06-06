using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.Data
{
    public class Card
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        [MaxLength(16)]
        public string Password { get; set; }
        [MaxLength(25)]
        public int UserId { get; set; }
        [Required]
        public User User { get; set; }
        List<BlockCard> BlockCard { get; set; } = new List<BlockCard>();
        List<Bill> Bill { get; set; } = new List<Bill>();
    }
}
