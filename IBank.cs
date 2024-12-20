using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankproject
{
    internal interface IBank
    {
        public void AddAccount (Account account);
        public void RemoveAccount (Account account);
        public string DisplayAllAccounts ();
        public decimal SumAllBalance();
        public Account FindAccount(long accountNumber);
        public string DisplayAllEmployess();

	}
}
