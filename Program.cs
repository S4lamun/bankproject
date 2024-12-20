using bankproject;
using System;

namespace bankproject
{
    class Program
    {

        public static void Test()
        {

            //      STWORZENIE BANKU


			Bank b1 = new("MyBank");



			

			

            //b1.AddEmployee(employee1);
            //b1.AddEmployee(employee2);




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
            



			Console.WriteLine(b1);

            

		}
        static void Main()
        {
            Test();

        }
    }
}