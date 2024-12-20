using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankproject
{
    internal class Account
    {
        Person owner;
        string password;
        decimal balance;
        long accountNumber; //26digits

        #region static
        static long bankAccountNumber;
        static Account()
        {
            bankAccountNumber = 00000000000000000000000001;
        }
        #endregion
       

        public Account(Person owner, string password) //contructor if owner doesn't give any money in deposite
        {
            this.owner = owner;
            this.password = password;
            balance = 0;
            accountNumber = bankAccountNumber;
            bankAccountNumber++;
        }

        public Account(Person owner, string password, decimal balance) // contrutor if owner deposit money
        {
            this.owner = owner;
            this.password = password;
            this.balance = balance;
            accountNumber = bankAccountNumber;
            bankAccountNumber++;
        }

        public void Transfer(Account a1, decimal amount)
        {
            if (balance<amount)
            {
                throw new WrongAmountException($"You don't have enough balance to transef {amount:C}");
            }
 
            a1.balance = a1.balance+amount;
            balance = balance - amount;
        }


        public override string ToString()
        {
            return $"{owner}, Balance: {balance:C}, Bank Account Number: {accountNumber:D26}";
        }



    }
}
