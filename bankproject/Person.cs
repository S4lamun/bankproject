using System.Text.RegularExpressions;

namespace bankproject;

public abstract class Person
{
    public string name;
    private string pesel;
    public EnumSex sex;
    public string surname;
    
    public Person() { }
    public Person(string name, string surname, string pesel, EnumSex sex)
    {
        this.name = name;
        this.surname = surname;
        Pesel = pesel;
        this.sex = sex;
    }

    #region Properties

    public string Pesel
    {
        get => pesel;
        set
        {
            if (!Regex.IsMatch(value, @"\d{11}")) throw new WrongPeselException("Pesel is invalid");
            pesel = value;
        }
    }

    #endregion

    public override string ToString()
    {
        return $"{name} {surname} [{sex}], PESEL: {Pesel}";
    }
}

public enum EnumSex
{
    K,
    M
}