using bankproject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class UnitTestsAccount
    {
        [TestMethod]
        public void TestTransferMoney()
        {
            Bank bank = new Bank("Testowy Bank");
            BankCustomer klient1 = new BankCustomer("Anna", "Nowak", "11111111111", EnumSex.K);
            BankCustomer klient2 = new BankCustomer("Adam", "Kowalski", "22222222222", EnumSex.M);
            Account k1 = new Account(klient1, "Password1", 200m);
            Account k2 = new Account(klient2, "Password12", 200m);
            bank.AddAccount(k1);
            bank.AddAccount(k2);
            
            k1.Transfer(k2, 100m);

            Assert.AreEqual(100m, k1.Balance);
            Assert.AreEqual(300m, k2.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(WrongAmountException))]
        public void TestTransferError()
        {
            Bank bank = new Bank("Testowy Bank");
            BankCustomer klient1 = new BankCustomer("Anna", "Nowak", "11111111111", EnumSex.K);
            BankCustomer klient2 = new BankCustomer("Adam", "Kowalski", "22222222222", EnumSex.M);
            Account k1 = new Account(klient1, "Password1", 200m);
            Account k2 = new Account(klient2, "Password12", 200m);
            bank.AddAccount(k1);
            bank.AddAccount(k2);

            k1.Transfer(k2, 500m);

        }

        [TestMethod]
        public void TestWithdraw()
        {
            BankCustomer klient1 = new BankCustomer("Anna", "Nowak", "11111111111", EnumSex.K);

            Account k1 = new Account(klient1, "Password1", 200m);
            k1.Withdraw(100m);

            Assert.AreEqual(100m, k1.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(WrongAmountException))]
        public void TestWithdrawException()
        {
            BankCustomer klient1 = new BankCustomer("Anna", "Nowak", "11111111111", EnumSex.K);

            Account k1 = new Account(klient1, "Password1", 200m);
            k1.Withdraw(300m);
        }

        [TestMethod]
        public void TestDonate()
        {
            BankCustomer klient1 = new BankCustomer("Anna", "Nowak", "11111111111", EnumSex.K);

            Account k1 = new Account(klient1, "Password1", 200m);
            k1.Donate(50m);

            Assert.AreEqual(250m, k1.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(WrongPasswordException))]
        public void TestPassword()
        {
            BankCustomer klient1 = new BankCustomer("Anna", "Nowak", "11111111111", EnumSex.K);

            Account k1 = new Account(klient1, "123", 200m);
        }
               
        [TestMethod]
        public void TestCompareTo()
        {
            BankCustomer klient1 = new BankCustomer("Anna", "Nowak", "11111111111", EnumSex.K);
            BankCustomer klient2 = new BankCustomer("Adam", "Kowalski", "22222222222", EnumSex.M);

            Account k1 = new Account(klient1, "Password1", 500m);
            Account k2 = new Account(klient2, "Password12", 300m);

            int comparisonResult = k1.CompareTo(k2);

            Assert.AreEqual(1, comparisonResult);
        }
    }
}
