using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bankproject;
namespace UnitTests
{
    [TestClass]
    public class UnitTestsBank
    {
       
        [TestMethod]
        public void TestListInicialization()
        {
            Bank b1 = new Bank("TestBank");
            
            Assert.IsNotNull(b1.accountsForXML);
        }
        
        [TestMethod]
        public void TestAddAccount()
        {
            Bank bank = new ("TestowyBank");
            bank.AddAccount(new());
            Assert.AreEqual(bank.accountsForXML.Count, 1);
        }
        [TestMethod]
        public void TestRemoveAccount()
        {
            
            Bank bank = new Bank("Testowy Bank");
            BankCustomer klient = new BankCustomer("Jan", "Drwal", "12345678901", EnumSex.M);
            Account konto = new Account(klient, "Password1", 100m);
            bank.AddAccount(konto);

            bank.RemoveAccount(konto);

            Assert.IsFalse(bank.accountsForXML.Contains(konto), "Konto nie zosta³o poprawnie usuniête z banku.");
        }
        [TestMethod]
        public void TestSumAllBalance()
        {
            
            Bank bank = new Bank("Testowy Bank");
            BankCustomer klient1 = new BankCustomer("Anna", "Nowak", "11111111111", EnumSex.K);
            BankCustomer klient2 = new BankCustomer("Adam", "Kowalski", "22222222222", EnumSex.M);

            bank.AddAccount(new Account(klient1, "Password1", 200m));
            bank.AddAccount(new Account(klient2, "Password12", 300m));

            decimal sumaSaldo = bank.SumAllBalance();

            Assert.AreEqual(500m, sumaSaldo);
        }

        [TestMethod]
        public void TestSaveXml()
        {
            
            Bank bank = new Bank("TestowyBank");
            

            bank.SaveXml("testBank.xml");

            Assert.IsTrue(File.Exists("testBank.xml"));

            File.Delete("testBank.xml");
        }
        [TestMethod]
        public void TestFindByAccountNo()
        {
            Bank bank = new Bank("Testowy Bank");
            BankCustomer klient = new BankCustomer("Jan", "Drwal", "12345678901", EnumSex.M);
            Account konto = new Account(klient, "Password1", 100m);
            bank.AddAccount(konto);
            Account znalezioneKonto = bank.FindAccount(konto.AccountNumber);
                        
            Assert.AreEqual(konto, znalezioneKonto);
        }
        
        
    }
}