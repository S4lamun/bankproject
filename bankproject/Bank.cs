using System.Security.Principal;
using System.Text;
using System.Xml.Serialization;

namespace bankproject;

[XmlInclude(typeof(Account))]
[XmlInclude(typeof(BankCustomer))]
[XmlInclude(typeof(BankEmployee))]
public class Bank : IBank //it's for admin 
{
    [XmlIgnore] public static Dictionary<long, Account> accounts;

    [XmlIgnore] public static Dictionary<long, BankEmployee> bankEmployees;

    public List<Account> accountsForXML;

    public List<BankEmployee> employeesForXML;

    public string name;

    
    public Bank() { }
    public Bank(string name)
    {
        this.name = name;

        accountsForXML = new List<Account>();

        employeesForXML = new List<BankEmployee>();


        bankEmployees = new Dictionary<long, BankEmployee>();


        accounts = new Dictionary<long, Account>();
        
    }

    #region BANK

    //TOTAL BANK BALANCE FROM ALL ACCOUNTS


    public virtual decimal SumAllBalance()
    {
        return accounts.Values.Sum(a => a.Balance);
    }

    #endregion


    public void SaveXml(string fileName)
    {
        using StreamWriter sr = new(fileName);
        XmlSerializer xs = new(typeof(Bank));
        xs.Serialize(sr, this);
    }

    public Bank ReadXml(string fileName)
    {
        using StreamReader sr = new(fileName);
        XmlSerializer xs = new(typeof(Bank));
        Bank myBank = (Bank)xs.Deserialize(sr);
        foreach (var employee in myBank.employeesForXML)
        {
            bankEmployees.Add(employee.EmployeeID, employee);
            employeesForXML.Add(employee);
        }
        foreach (var account in  myBank.accountsForXML)
        {
            accounts.Add(account.AccountNumber, account);
            accountsForXML.Add(account);
        }
        return myBank;
    }


    public override string ToString()
    {
        return
            $" \"Welcome in {name}\" \n \t \t Summarized balance: {SumAllBalance():C} \n\n\nAccounts in \"{name}\": {DisplayAllAccounts()}" +
            $"\nList of employees: {DisplayAllEmployess()}";
    }


    public static void CreateBank()
    {
        
        Bank b1 = new("MyBank");

       
        BankEmployee employee1 = new("Jan", "Nowak", "11111111111", EnumSex.M, 1, "HasloPracownika1");
        BankEmployee employee2 = new("Adam", "Kowalski", "22222222222", EnumSex.M, 2, "HasloPracownika2");
        BankEmployee employee3 = new("Filip", "Dzban", "66666666666", EnumSex.M, 3, "HASELKO4");
       

        BankCustomer customer1 = new("Marian", "Warzecha", "78787878787", EnumSex.M);
        BankCustomer customer2 = new("Maja", "Ujoska", "66666666666", EnumSex.K);
        BankCustomer customer3 = new("Hania", "Genzi", "65656565656", EnumSex.K);


        Account a1 = new(customer1, "HASELKO1", 3m);
        Account a2 = new(customer2, "HASELKO2", 500m);
        Account a3 = new(customer3, "HASELKO3", 1500m);

        b1.AddEmployee(employee1);
        b1.AddEmployee(employee2);
        b1.AddEmployee(employee3);



        b1.AddAccount(a1);
        b1.AddAccount(a2);
        b1.AddAccount(a3);

        

        b1.SaveXml("MyBank.xml");
    }

  
    

    #region EMPLOYEE

    //ADDING EMPLOYEE TO EMPLOYEES LIST


    public void AddEmployee(BankEmployee employee)
    {
        if (!bankEmployees.ContainsKey(employee.EmployeeID))
        {
            bankEmployees.Add(employee.EmployeeID, employee);
            employeesForXML.Add(employee);
        }

        else Console.WriteLine($"There is an employee which this Employee ID! {employee.EmployeeID}");
    }


    //REMOVING EMPLOYEE FROM THE EMPLOYEES LIST


    public void RemoveEmployee(BankEmployee employee)
    {
        if (bankEmployees.ContainsKey(employee.EmployeeID))
        {
            bankEmployees.Remove(employee.EmployeeID);
            employeesForXML.Remove(employee);
        }
        else Console.WriteLine($"There is not employee which this Employee ID! {employee.EmployeeID}");
    }

    

    public BankEmployee? FindEmployee(string password)
    {
        return bankEmployees.Values.FirstOrDefault(t => t.EmployeePassword == password); // searching dictionary by password
    }


    //DISPLAYING ALL ACCOUNTS FROM THE BANK
    public string DisplayAllEmployess()
    {
        var sb = new StringBuilder();
        var i = 1;
        sb.Append("\n");
        foreach (var employee in bankEmployees.Values)
        {
            sb.AppendLine($"{i}. " + employee);
            i++;
        }

        return sb.ToString();
    }

    #endregion
    

    #region ACCOUNT

    //ADDING ACCOUNT TO THE BANK


    public void AddAccount(Account account)
    {
        if (!accounts.ContainsKey(account.AccountNumber))
        {
            accounts.Add(account.AccountNumber, account);
            accountsForXML.Add(account);
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
            accountsForXML.Remove(account);
        }
        else Console.WriteLine($"There is not account which this Account Number! {account.AccountNumber}");
    }


    //DISPLAYING ALL ACCOUNTS FROM THE BANK


    public string DisplayAllAccounts()
    {
        var sb = new StringBuilder();
        var i = 1;
        sb.Append("\n");
        if (accounts.Count == 0) return "Accounts list is empty";

        foreach (var account in accounts.Values)
        {
            sb.AppendLine($"{i}. " + account);
            i++;
        }

        return sb.ToString();
    }


    //FINDING ACCOUNT IN THE BANK


    public Account FindAccount(long accountNumber)
    {
        if (accounts.ContainsKey(accountNumber)) return accounts[accountNumber];

        throw new WrongAccountException($"There is no account with this number: {accountNumber}");
    }


    public Account? FindAccount(string password)
    {
        return accounts.Values.FirstOrDefault(t => t.Password == password); // searching dictionary by password
    }

    #endregion
}