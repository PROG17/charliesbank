using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CharlieBankApp.Models
{
    public class BankActionIndexViewModel
    {
        [DisplayName("Kontonummer")]
        [Required(ErrorMessage = "Du måste fylla i kontonummer!")]
        public int AccountNumber { get; set; }

        [DisplayName("summa")]
        [Required(ErrorMessage = "Du måste fylla i summan!")]
        [Range(1, 999999)]
        public decimal Amount { get; set; }

        public string Message { get; set; }

        public decimal Balance { get; set; }
    }
}
