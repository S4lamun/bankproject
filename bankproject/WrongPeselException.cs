﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankproject
{
    public class WrongPeselException:Exception
    {
        string message;
        public WrongPeselException(string message) 
        {
            this.message = message;
        }
        
    }
}