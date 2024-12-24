namespace bankproject;

public class BankCustomer : Person
{
    public BankCustomer() { }
    public BankCustomer(string name, string surname, string pesel, EnumSex sex) : base(name, surname, pesel, sex)
    {
    }
}