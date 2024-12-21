using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;



namespace bankproject
{
	[XmlInclude(typeof(Account))]
	[XmlInclude(typeof(BankCustomer))]
	[XmlInclude(typeof(BankEmployee))]

	public class Bank : IBank //it's for admin 
	{
		

		public string name;

		[XmlIgnore]
		public static Dictionary<long, Account> accounts;

		public List<Account> accountsForXML;

		[XmlIgnore]
		public static Dictionary<long, BankEmployee> bankEmployees;

		public List<BankEmployee> employeesForXML;

		public Bank() { }
		public Bank(string name)
		{
			this.name = name;

			accountsForXML = new List<Account>
			{
			{a1},
			{a2},
			{a3}

			};
			employeesForXML = new List<BankEmployee>
			{

			{employee1},

			{employee2}

			};



			bankEmployees = new Dictionary<long, BankEmployee>
			{

			{employee1.EmployeeID,employee1},

			{employee2.EmployeeID,employee2}

			};


			accounts = new Dictionary<long, Account>
			{
			{a1.AccountNumber, a1 },
			{a2.AccountNumber, a2 },
			{a3.AccountNumber, a3 }

			};

		}
		//		INITIATION
		#region INITIATION


								//EMPLOYEES INITIATION


		static BankEmployee employee1 = new("Jan", "Nowak", "11111111111", EnumSex.M, 1, "HasloPracownika1");
		static BankEmployee employee2 = new("Adam", "Kowalski", "22222222222", EnumSex.M, 2, "HasloPracownika2");


		



								//CUSTOMERS INITIATION


		static BankCustomer customer1 = new("Marian", "Warzecha", "78787878787", EnumSex.M);
		static BankCustomer customer2 = new("Maja", "Ujoska", "66666666666", EnumSex.K);
		static BankCustomer customer3 = new("Hania", "Genzi", "65656565656", EnumSex.K);




								//ACCOUNTS INITIATION


		static Account a1 = new(customer1, "HASELKO1", 3m);
		static Account a2 = new(customer2, "HASELKO2", 500m);
		static Account a3 = new(customer3, "HASELKO3", 1500m);


        
		// nie da sie ich usunac, bo lista dictionary jest tworzone od razu z nimi
		#endregion


		//		EMPLOYEE STUFF
		#region EMPLOYEE


								//ADDING EMPLOYEE TO EMPLOYEES LIST


		public void AddEmployee(BankEmployee employee)
		{
			bankEmployees.Add(employee.EmployeeID, employee);
		}


								//REMOVING EMPLOYEE FROM THE EMPLOYEES LIST


		public void RemoveEmployee(BankEmployee employee)
		{

			if (bankEmployees.ContainsKey(employee.EmployeeID))
			{
				bankEmployees.Remove(employee.EmployeeID);
			}
			else Console.WriteLine($"There is not employee which this Employee ID! {employee.EmployeeID}");

		}



		//DISPLAYING ALL ACCOUNTS FROM THE BANK
		public string DisplayAllEmployess()
		{
			StringBuilder sb = new StringBuilder();
			int i = 1;
			sb.Append("\n");
			foreach (BankEmployee employee in bankEmployees.Values)
			{
				sb.AppendLine($"{i}. " + employee.ToString());
				i++;
			}
			return sb.ToString();
		}
		#endregion


		//		ACCOUNT STUFF
		#region ACCOUNT


								//ADDING ACCOUNT TO THE BANK


		public void AddAccount(Account account) => accounts.Add(account.AccountNumber, account); 


								//REMOVING ACCOUNT FROM THE BANK


		public void RemoveAccount(Account account) 
        {
            
            if (accounts.ContainsKey(account.AccountNumber))
            {
                accounts.Remove(account.AccountNumber);
            }
            else Console.WriteLine($"There is not account which this Account Number! {account.AccountNumber}");

        }


								//DISPLAYING ALL ACCOUNTS FROM THE BANK


		public string DisplayAllAccounts() 
        {
            StringBuilder sb = new StringBuilder();
            int i = 1;
            sb.Append("\n");
            if (accounts.Count == 0)
            {
                return "Accounts list is empty";
            }
            else
            {
                foreach (var account in accounts.Values)
                {
                    sb.AppendLine($"{i}. " + account.ToString());
                    i++;
                }
                return sb.ToString();
            }
        }


								//FINDING ACCOUNT IN THE BANK


		public Account FindAccount(long accountNumber)      // nie jestem pewny czy to dobrze dziala
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
#endregion 


		//		BANK STUFF
		#region BANK



								//TOTAL BANK BALANCE FROM ALL ACCOUNTS


		public virtual decimal SumAllBalance() => accounts.Values.Sum(a => a.Balance);
		#endregion



		public void SaveXml(string fileName)
		{
			using StreamWriter sr = new(fileName);
			XmlSerializer xs = new(typeof(Bank));
			xs.Serialize(sr, this);

		}
		public static Bank ReadXML(string fileName)
		{
			using StreamReader sr = new(fileName);
			XmlSerializer xs = new(typeof(Bank));
			return xs.Deserialize(sr) as Bank;
		}





		public override string ToString() 
        {

            return $" \"Welcome in {name}\" \n \t \t Summarized balance: {SumAllBalance():C} \n\n\nAccounts in \"{name}\": {DisplayAllAccounts().ToString()}" + $"\nList of employees: {DisplayAllEmployess()}";
                
        }



		




		private bool AskForIDAndPassword()
		{
			Console.WriteLine("Insert ID:");
			string userInput = Console.ReadLine();



			if (!long.TryParse(userInput, out long result)) { Console.WriteLine("Invalid ID (ID is not numeric)"); return false; };

			long inputID = result;

			Console.WriteLine("Password:");
			string inputPass = Console.ReadLine();



			if (!bankEmployees.ContainsKey((inputID)))
			{
				Console.WriteLine("Invalid ID or password");
				return false;
			}

			return true;


		}
	}
}
