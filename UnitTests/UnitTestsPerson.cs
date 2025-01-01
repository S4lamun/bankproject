using bankproject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class UnitTestsPerson
    {
        [TestMethod]
        [ExpectedException(typeof(WrongPeselException))]
        public void TestPESELException()
        {
            BankCustomer c1 = new BankCustomer();
            Assert.Fail(c1.Pesel = "123");
        }
        [TestMethod]
        public void TestBankCustomerConstructor()
        {
            
            string name = "Jan";
            string surname = "Kowalski";
            string pesel = "12345678901";
            EnumSex sex = EnumSex.M;

            BankCustomer customer = new BankCustomer(name, surname, pesel, sex);

            Assert.AreEqual(name, customer.name);
            Assert.AreEqual(surname, customer.surname);
            Assert.AreEqual(pesel, customer.Pesel);
            Assert.AreEqual(sex, customer.sex);
        }

        [TestMethod]
        public void TestBankEmployeeConstructor()
        {
            string name = "Anna";
            string surname = "Nowak";
            string pesel = "12345678901";
            EnumSex sex = EnumSex.K;
            long employeeID = 12345;
            string password = "Passw1";

            BankEmployee employee = new BankEmployee(name, surname, pesel, sex, employeeID, password);

            Assert.AreEqual(name, employee.name);
            Assert.AreEqual(surname, employee.surname);
            Assert.AreEqual(pesel, employee.Pesel);
            Assert.AreEqual(sex, employee.sex);
            Assert.AreEqual(employeeID, employee.EmployeeID);
            Assert.AreEqual(password, employee.EmployeePassword);
        }

        [TestMethod]
        [ExpectedException(typeof(WrongPasswordException))]
        public void TestInvalidEmployeePassword_TooShort()
        {
            
            BankEmployee e1 = new BankEmployee("Anna", "Nowak", "12345678901", EnumSex.K, 12345, "P1");
        }

        [TestMethod]
        public void TestToStringBankCustomer()
        {
            
            BankCustomer customer = new BankCustomer("Jan", "Kowalski", "12345678901", EnumSex.M);

            string result = customer.ToString();
            Assert.AreEqual("Jan Kowalski [M], PESEL: 12345678901", result);
        }
        [TestMethod]
        public void TestToStringBankEmployee()
        {
            
            BankEmployee employee = new BankEmployee("Anna", "Nowak", "12345678901", EnumSex.K, 12345, "Passw1");

            string result = employee.ToString();

            Assert.AreEqual("Anna Nowak [K], PESEL: 12345678901, Employee ID: 12345", result);
        }
    }
}
