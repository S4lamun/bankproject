using System.Text.RegularExpressions;

//Password nie jest uzywany, probowalem jako dictionary zrobic, ale wtedy id moglo sie powtorzyc z innym haslem.
namespace bankproject;

public class BankEmployee : Person
{
    private readonly string employeePassword;
    static long employeeID;


    public BankEmployee() { }
    public BankEmployee(string name, string surname, string pesel, EnumSex sex, long employeeID,
        string employeePassword) : base(name, surname, pesel, sex)
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
                throw new WrongPasswordException("Password must have at least 1 capital letter, 1 digit, and be at least 6 characters long (no special characters).");
            employeePassword = value;
        }
    }


    public long EmployeeID { get; set; }

    public override string ToString()
    {

        return base.ToString() + $", Employee ID: {EmployeeID}";
    }
}