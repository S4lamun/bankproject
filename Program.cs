using bankproject;
using System; 
class Program
{

    public static void Test()
    {
  
        Person p1 = new("Jan", "Nowak", "11111111111", EnumSex.M);
        Person p2 = new("Adam", "Kowalski", "22222222222", EnumSex.M);

        Account a1 = new(p1, "Lolek1");
        Account a2 = new(p2, "fJ2lek", 500m);
        
       

        Bank b1 = new("MyBank");
        b1.AddAccount(a1);
        b1.AddAccount(a2);
        Console.WriteLine(b1);
        
        

    }
    static void Main()
    {
        Test();
        
    }
}