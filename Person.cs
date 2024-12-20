using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace bankproject
{
    internal class Person
    {
        string name;
        string surrname;
        string pesel;
        #region Properties
        public string Pesel
        {
            get => pesel;
            set
            {
                if(Regex.IsMatch(value,@"\d{11}"))
                {
                    throw new WrongPeselException("Pesel is invalid");
                }
                pesel = value;
            }
        }
        #endregion

        public Person(string name, string surrname, string pesel)
        {
            this.name = name;
            this.surrname = surrname;
            Pesel = pesel;
        }

        public override string ToString()
        {
            return $"{name} {surrname}, PESEL: {Pesel}";
        }

        
    }
}
