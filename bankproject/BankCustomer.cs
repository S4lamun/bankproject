namespace bankproject;

public class BankCustomer : Person, ICloneable
{
    public BankCustomer() { }
    public BankCustomer(string name, string surname, string pesel, EnumSex sex) : base(name, surname, pesel, sex)
    {
    }

    public object Clone()
    {
        {
            return new BankCustomer
            {
                name = this.name,
                surname = this.surname,
                Pesel = this.Pesel,
                sex = this.sex
            };
        }
    }
}