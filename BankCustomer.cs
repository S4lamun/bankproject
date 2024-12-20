using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace bankproject
{
	public class BankCustomer : Person
	{

		

		public BankCustomer(string name, string surrname, string pesel, EnumSex sex) : base(name, surrname, pesel, sex) 
		{
		}
	}
}
