using CharlieBankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharlieBankApp.Data
{
    public class BankRepostitory
    {
        public List<Customer> CustomerList { get; set; }

        public string BankWithdraw(int accountNumber, decimal amount)
        {
            Account account;
            foreach (var item in this.CustomerList)
            {
                var acc = item.CustomerAccounts.Where(x => x.AccountNumber == accountNumber);
                if (acc.Count() > 0)
                {
                    account = acc.FirstOrDefault();
                    if (account.Balance > amount)
                    {
                        account.Balance -= amount;
                        return "Lyckades med uttaget, nya saldot är: " + account.Balance + "Kr";
                    }
                    return "Täckning saknas";
                }
            }

            return "Kontot hittades inte";      
        }

        public string BankDeposit(int accountNumber, decimal amount)
        {
            var account = new Account();
            foreach (var item in this.CustomerList)
            {
                var acc = item.CustomerAccounts.Where(x => x.AccountNumber == accountNumber);
                if (acc.Count() > 0)
                {
                    account = acc.FirstOrDefault();

                    account.Balance += amount;
                    return "Lyckades med insättningen, nya saldot är: " + account.Balance + "Kr";
                }
            }

            return "Kontot hittades inte";       
        }

        public BankRepostitory()
        {
            var listOfCustomers = new List<Customer>();
            var listOfRandomNames = new List<string>() { "Henrik dahl", "Kapten Mygel", "Henrietta Bruno" };
            for (int i = 0; i < 3; i++)
            {
                var account = new Account() { AccountNumber = i + 1, Balance = (i + 1) * 1000 };
                var customer = new Customer() { CustomerAccounts = new List<Account>(), CustomerNumber = i + 1, Name = listOfRandomNames[i] };
                customer.CustomerAccounts.Add(account);
                listOfCustomers.Add(customer);
            }
            var acc = new Account() { AccountNumber = 100, Balance = 2222 };
            listOfCustomers[1].CustomerAccounts.Add(acc);
            this.CustomerList = listOfCustomers;
        }
    }
}
