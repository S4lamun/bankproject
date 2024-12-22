using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankproject
{
    internal class WrongAmountException:Exception
    {
        string message;
        public WrongAmountException(string message)
        {
            this.message = message;
        }
    }
}
