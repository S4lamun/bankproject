using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace bankproject
{
    public class Account : IComparable<Account>
    {
        
        BankCustomer owner;
        string password;
        decimal balance;
        long accountNumber; //26digits

        #region 
        static long bankAccountNumber;
        public Account() { }
        static Account()
        {
            bankAccountNumber = 00000000000000000000000001;
			

		}
        #endregion

        #region Properties
        public string Password // password must have at least: 1 capital letter, 1 digit, 1 special character and must be at least 6 characters long    
        {
            get => password;
            init
            {
                if (!Regex.IsMatch(value, @"^(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{6,}$"))
                {
                    throw new WrongPasswordException("Password must have at least 1 capital letter, 1 digit, and be at least 6 characters long (no special characters).");
                }
                password = value;
            }
        }
        public long AccountNumber { get => accountNumber; init => accountNumber = value; }
        public decimal Balance { get => balance; set => balance = value; }

        public BankCustomer Owner { get => owner; set => owner = value; }

        #endregion



        public Account(BankCustomer owner, string password) //contructor if owner doesn't give any money in deposite
        {
            this.owner = owner;
            Password = password;
            Balance = 0;
            AccountNumber = bankAccountNumber;
            bankAccountNumber++;
        }

        public Account(BankCustomer owner, string password, decimal balance) // contrutor if owner deposit money
        {
            this.owner = owner;
            Password = password;
            this.Balance = balance;
            AccountNumber = bankAccountNumber;
            bankAccountNumber++;
        }


     









        public void Transfer(Account a1, decimal amount)
        {
            if (Balance<amount)
            {
                throw new WrongAmountException($"You don't have enough balance to transef {amount:C}");
            }
 
            a1.Balance = a1.Balance+amount;
            Balance = Balance - amount;
        }

        public void Donate(decimal amount)
        {
            balance = balance + amount;
            Console.WriteLine($"You donated {amount:C} and now your balance is: {balance:C}");
        }
        public void Withdraw(decimal amount)
        {
            if (Balance < amount)
            {
                throw new WrongAmountException($"You don't have enough balance to withdraw {amount:C}");
            }
             balance = balance - amount;
            Console.WriteLine($"You withdrawed {amount:C} and now your balance is: {balance:C}");
        }


        public override string ToString()
        {
            return $"{owner}, Balance: {Balance:C}, Bank Account Number: {AccountNumber:D26}";
        }

        public int CompareTo(Account? other)
        {
            if (other == null) return 1;
            else return Balance.CompareTo(other.Balance);
        }



    }
}
