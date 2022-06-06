using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankATM.Data
{
    public class Bill
    {
        public int Id { get; set; }
        public string BillNumber { get; set; }
        [MaxLength(25)]
        public Decimal Balance { get; set; }
        public int CardId { get; set; }
        [Required]
        public Card Card { get; set; }
        List<Transactions> Transactions { get; set; } = new List <Transactions>();

    }
}
