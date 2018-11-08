using CharlieBankApp.Data;
using System;
using Xunit;

namespace CharlieBankAppTests
{
    public class BankTests
    {
        BankRepostitory BankRepo = new BankRepostitory();

        [Fact]
        public void TryWithdraw()
        {
            var customerToTest = BankRepo.CustomerList[0];
 
            BankRepo.BankWithdraw(customerToTest.CustomerAccounts[0].AccountNumber, 100);

            Assert.Equal(900, customerToTest.CustomerAccounts[0].Balance);
        }

        [Fact]
        public void TryDeposit()
        {
            var customerToTest = BankRepo.CustomerList[0];

            BankRepo.BankDeposit(customerToTest.CustomerAccounts[0].AccountNumber, 100);

            Assert.Equal(1100, customerToTest.CustomerAccounts[0].Balance);
        }

        [Fact]
        public void TryOverWithdrawMessage()
        {
            var customerToTest = BankRepo.CustomerList[0];

            var result = BankRepo.BankWithdraw(customerToTest.CustomerAccounts[0].AccountNumber, 1100);

            Assert.Equal("Täckning saknas", result);
        }

        [Fact]
        public void TryOverWithdraw()
        {
            var customerToTest = BankRepo.CustomerList[0];

            var result = BankRepo.BankWithdraw(customerToTest.CustomerAccounts[0].AccountNumber, 1100);

            Assert.Equal(1000, customerToTest.CustomerAccounts[0].Balance);
        }
    }
}
