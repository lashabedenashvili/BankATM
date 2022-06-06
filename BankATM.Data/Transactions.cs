using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.Data
{
    public class Transactions
    {
        public int Id { get; set; }
        public DateTime WithdrowTime { get; set; }
        public Decimal WithdrawAmount { get; set; }
        public int BillId { get; set; }
        [Required]
        public Bill bill { get; set; }
    }
}
