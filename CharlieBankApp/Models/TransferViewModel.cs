using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CharlieBankApp.Models
{
    public class TransferViewModel
    {
        [DisplayName("Från konto")]
        public int FromAccountId { get; set; }
        [DisplayName("Till konto")]
        public int ToAccountId { get; set; }
        [DisplayName("Summa")]
        public decimal Amount { get; set; }
        public string Message { get; set; }
    }
}
