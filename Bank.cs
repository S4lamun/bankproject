using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace bankproject
{
    internal class Bank : IBank //it's for admin
    {
        string name;
        Dictionary<long, Account> accounts;

        public Bank(string name)
        {
            this.name = name;
            accounts = new();
        }

        public void AddAccount(Account account) => accounts.Add(account.AccountNumber, account); //adding account to bank
        public void RemoveAccount(Account account) //Removing account from bank
        {
            if (accounts.ContainsKey(account.AccountNumber))
            {
                accounts.Remove(account.AccountNumber);
            }
            else Console.WriteLine($"There is not account which this Account Number! {account.AccountNumber}");
        }
        public void DisplayAllAccounts() //displaying all accounts in bank
        {
            foreach (var account in accounts.Values)
            {
                Console.WriteLine(account.ToString());
            }
        }

        public decimal SumAllBalance() => accounts.Values.Sum(a => a.Balance); //its sums balance from all acounts

        public Account FindAccount(long accountNumber)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                return accounts[accountNumber];
            }
            else
            {
                throw new WrongAccountException($"There is no account with this number: {accountNumber}");
            }
        }

        public override string ToString() // do przerobienia to jest
        {
            Console.WriteLine($"\"{name}\"\t\t Summarized balance: {SumAllBalance():C}");
            Console.WriteLine($"Accounts in \"{name}\":");
            DisplayAllAccounts();
                return "";
        }


    }
}
