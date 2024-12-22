using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//Password nie jest uzywany, probowalem jako dictionary zrobic, ale wtedy id moglo sie powtorzyc z innym haslem.
namespace bankproject
{
	public class BankEmployee : Person
	{

		private long employeeID;
		private string employeePassword;

		public BankEmployee() { }
		public BankEmployee(string name, string surrname, string pesel, EnumSex sex, long employeeID, string employeePassword) :base(name, surrname, pesel, sex) 
		{
			EmployeeID = employeeID;
			EmployeePassword = employeePassword;

		}

		public string EmployeePassword			
		{
			get => employeePassword;
			init
			{
				if (!Regex.IsMatch(value, @"^(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{6,}$"))
				{
					throw new WrongPasswordException("Password must have at least 1 capital letter, 1 digit, and be at least 6 characters long (no special characters).");
				}
				employeePassword = value;
			}
		}


		public long EmployeeID 
		{
		get => employeeID;
		set => employeeID = value;
		}

		public override string ToString()
		{
			return base.ToString() + $", Employee ID: {employeeID}";
		}




	}
}
