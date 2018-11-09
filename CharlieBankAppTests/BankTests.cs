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
            var customerToTest = BankRepostitory.CustomerList[0];
            var initialBalance = customerToTest.CustomerAccounts[0].Balance;

            BankRepo.BankWithdraw(customerToTest.CustomerAccounts[0].AccountNumber, 100);

            Assert.Equal(initialBalance - 100, customerToTest.CustomerAccounts[0].Balance);
        }

        [Fact]
        public void TryDeposit()
        {
            var customerToTest = BankRepostitory.CustomerList[0];
            var initialBalance = customerToTest.CustomerAccounts[0].Balance;

            BankRepo.BankDeposit(customerToTest.CustomerAccounts[0].AccountNumber, 100);

            Assert.Equal(initialBalance + 100, customerToTest.CustomerAccounts[0].Balance);
        }

        [Fact]
        public void TryOverWithdrawMessage()
        {
            var customerToTest = BankRepostitory.CustomerList[0];

            var result = BankRepo.BankWithdraw(customerToTest.CustomerAccounts[0].AccountNumber, 1100);

            Assert.Equal("Täckning saknas", result);
        }

        [Fact]
        public void TryOverWithdraw()
        {
            var customerToTest = BankRepostitory.CustomerList[0];
            var initialBalance = customerToTest.CustomerAccounts[0].Balance;

            var result = BankRepo.BankWithdraw(customerToTest.CustomerAccounts[0].AccountNumber, 1100);

            Assert.Equal(initialBalance, customerToTest.CustomerAccounts[0].Balance);
        }

        [Fact]
        public void TryTransferFromAccount()
        {
            var customerToTest = BankRepostitory.CustomerList[0];
            var recievingCustomer = BankRepostitory.CustomerList[1];
            var initialBalance = customerToTest.CustomerAccounts[0].Balance;

            customerToTest.CustomerAccounts[0].Transfer(recievingCustomer.CustomerNumber, 100);
            Assert.Equal(initialBalance - 100, customerToTest.CustomerAccounts[0].Balance);


        }

        [Fact]
        public void TryTransferToAccount()
        {
            var customerToSend = BankRepostitory.CustomerList[0];
            var recievingCustomer = BankRepostitory.CustomerList[1];
            var initialBalance = recievingCustomer.CustomerAccounts[0].Balance;

            customerToSend.CustomerAccounts[0].Transfer(recievingCustomer.CustomerNumber, 100);
            Assert.Equal(initialBalance + 100, recievingCustomer.CustomerAccounts[0].Balance);
        }

        [Fact]
        public void TryOverTransferToAccount()
        {
           
            var initialBalance1 = BankRepostitory.CustomerList[1].CustomerAccounts[0].Balance;
            var initialBalance = BankRepostitory.CustomerList[0].CustomerAccounts[0].Balance;

            var result = BankRepostitory.CustomerList[0].CustomerAccounts[0].Transfer(2, 20000);

            Assert.Equal(initialBalance1, BankRepostitory.CustomerList[1].CustomerAccounts[0].Balance);
            Assert.Equal(initialBalance, BankRepostitory.CustomerList[0].CustomerAccounts[0].Balance);
            Assert.Equal("Överföring misslyckades", result);
        }
    }
}
