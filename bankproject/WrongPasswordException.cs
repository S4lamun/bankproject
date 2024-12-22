using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankproject
{
    public class WrongPasswordException:Exception
    {
        string message;
        public WrongPasswordException(string message)
        {
            this.message = message;
        }
    }
}
