using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.Data
{
    public class BlockCard
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        [Required]
        public Card Card { get; set; }
    }
}
