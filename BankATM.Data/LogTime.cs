using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.Data
{
    public class LogTime
    {
        public int Id { get; set; }
        public DateTime Login { get; set; }
        public DateTime? MyProperty { get; set; } = null;
        public int UserId { get; set; }
        [Required]
        public User user { get; set; }
    }
}
