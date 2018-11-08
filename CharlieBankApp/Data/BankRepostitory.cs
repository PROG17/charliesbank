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
