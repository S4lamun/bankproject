﻿using System.Text;
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

		//public Bank(string name)
		//{
		//	this.name = name;
  //          accounts = new Dictionary<long, Account>();
  //          bankEmployees = new Dictionary<long, BankEmployee>();
  //      }
		
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
			

			if (!bankEmployees.ContainsKey(employee.EmployeeID))
			{
				bankEmployees.Add(employee.EmployeeID, employee);
			}
			else Console.WriteLine($"There is an employee which this Employee ID! {employee.EmployeeID}");
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

		public bool FindEmpolyee(string password)
		{
			return bankEmployees.Values.Any(t => t.EmployeePassword == password);
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


		public void AddAccount(Account account)
		{
			
			if (!accounts.ContainsKey(account.AccountNumber))
			{
				accounts.Add(account.AccountNumber, account);
			}
			else
			throw new WrongAccountException($"There is an account which this Account Number! {account.AccountNumber}");
		}


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
				foreach (Account account in accounts.Values)
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


		public Account? FindAccount(string password)
		{
            return accounts.Values.FirstOrDefault(t => t.Password == password); // searching dictionary by password
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





        public static void CreateBank()
        {

            //      STWORZENIE BANKU


            Bank b1 = new("MyBank");

            BankEmployee employee3 = new("Filip", "Dzban", "66666666666", EnumSex.M, 2, "HASELKO4");
            b1.AddEmployee(employee3);
			BankEmployee employee1 = new("Jan", "Nowak", "11111111111", EnumSex.M, 1, "HasloPracownika1");
			BankEmployee employee2 = new("Adam", "Kowalski", "22222222222", EnumSex.M, 2, "HasloPracownika2");






			//CUSTOMERS INITIATION


			BankCustomer customer1 = new("Marian", "Warzecha", "78787878787", EnumSex.M);
			BankCustomer customer2 = new("Maja", "Ujoska", "66666666666", EnumSex.K);
			BankCustomer customer3 = new("Hania", "Genzi", "65656565656", EnumSex.K);




			//ACCOUNTS INITIATION


			Account a1 = new(customer1, "HASELKO1", 3m);
			Account a2 = new(customer2, "HASELKO2", 500m);
			Account a3 = new(customer3, "HASELKO3", 1500m);


			BankCustomer customer4 = new("Jan", "Dzban", "33333333333", EnumSex.M);
            BankCustomer customer5 = new("Marianna", "Dzban", "44444444444", EnumSex.K);
            BankCustomer customer6 = new("Andrzej", "Baranowski", "55555555555", EnumSex.M);



            Account a4 = new(customer4, "HASELKO1", 3m);
            Account a5 = new(customer5, "HASELKO2", 500m);
            Account a6 = new(customer6, "HASELKO3", 1500m);






            b1.AddAccount(a4);
            b1.AddAccount(a5);
            b1.AddAccount(a6);

            //Console.WriteLine(b1.FindAccount(1));




            //Console.WriteLine(b1);

            b1.SaveXml("MyBank.xml");

        }
    }
}