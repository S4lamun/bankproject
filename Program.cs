using bankproject;
using System; 
class Program
{
    static void Main()
    {
        Console.WriteLine("Hello world!");
        Console.WriteLine("Yoooo");
		Console.WriteLine("ELO");

        Person p1 = new("Jan", "Nowak", "11111111111");
        Person p2 = new("Adam", "Kowalski", "22222222222");
        Console.WriteLine(p1);
        Console.WriteLine(p2);

        Account a1 = new(p1, "lolek");
        Account a2 = new(p2, "fjolek", 500m);
        Console.WriteLine(a1);
        Console.WriteLine(a2);
        a1.Transfer(a2, 200m);
        Console.WriteLine(a1);
        Console.WriteLine(a2);


      
    }
}