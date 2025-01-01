using System.Runtime.Intrinsics.X86;
using System.Data;
using System.Data.SqlClient;
using Mysqlx.Crud;

namespace bankproject;

internal class Program
{
    private static void Main()
    {
        BankCustomer customer = new BankCustomer("Jan", "Kowalski", "12345678901", EnumSex.M);

        string result = customer.ToString();
        //Assert.AreEqual("Jan Kowalski [M], PESEL: 12345678901", result);
        //Bank.CreateBank();

    }
}