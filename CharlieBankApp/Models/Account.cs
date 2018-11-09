using CharlieBankApp.Data;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharlieBankApp.Models
{
    public class Account
    {
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string Transfer(int recieverId, int input)
        {
            if (this.Balance < input)
            {
                return "Överföring misslyckades";
            }
            this.Balance -= input;
            Customer reciever = BankRepostitory.CustomerList.Where(c => c.CustomerAccounts.Select(a => a.AccountNumber == recieverId).FirstOrDefault()).FirstOrDefault();
            Account recieverAccount = BankRepostitory.GetAccountFromAccountNumber(recieverId);
            if (recieverAccount == null)
            {
                return "Felaktigt mottagarkonto! Kontonummer: " + recieverId;
            }
            var customerIndex = BankRepostitory.CustomerList.IndexOf(reciever);
            var accountindex = BankRepostitory.CustomerList[customerIndex].CustomerAccounts.IndexOf(recieverAccount);
            BankRepostitory.CustomerList[customerIndex].CustomerAccounts[accountindex].Balance += input;

            return "Överföring lyckades nya saldot är: " + this.Balance + "kr";
        }
    }

}
