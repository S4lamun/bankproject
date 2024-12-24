using System.Text.RegularExpressions;

namespace bankproject;

public class Account : IComparable<Account>
{
    private readonly string password;
    public Account() { }
    public Account(BankCustomer owner, string password, decimal balance)
    {
        this.Owner = owner;
        Password = password;
        Balance = balance;
        AccountNumber = bankAccountNumber;
        bankAccountNumber++;
    }

    public int CompareTo(Account? other)
    {
        if (other == null) return 1;
        return Balance.CompareTo(other.Balance);
    }


    public void Transfer(Account a1, decimal amount)
    {
        if (Balance < amount) throw new WrongAmountException($"You don't have enough balance to transfer {amount:C}");

        a1.Balance += amount;
        Balance -= amount;
    }

    public void Donate(decimal amount)
    {
        Balance += amount;
        Console.WriteLine($"You donated {amount:C} and now your balance is: {Balance:C}");
    }

    public void Withdraw(decimal amount)
    {
        if (Balance < amount) throw new WrongAmountException($"You don't have enough balance to withdraw {amount:C}");
        Balance -= amount;
        Console.WriteLine($"You withdrawed {amount:C} and now your balance is: {Balance:C}");
    }


    public override string ToString()
    {
        return $"{Owner}, Balance: {Balance:C}, Bank Account Number: {AccountNumber:D19}";
    }

    #region

    private static long bankAccountNumber;
    
    static Account()
    {
        bankAccountNumber = 0000000000000000001;
    }

    #endregion

    #region Properties

    public string
        Password // password must have at least: 1 capital letter, 1 digit, 1 special character and must be at least 6 characters long    
    {
        get => password;
        init
        {
            if (!Regex.IsMatch(value, @"^(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{6,}$"))
                throw new WrongPasswordException(
                    "Password must have at least 1 capital letter, 1 digit, and be at least 6 characters long (no special characters).");
            password = value;
        }
    }

    public long AccountNumber { get; init; }

    public decimal Balance { get; set; }

    public BankCustomer Owner { get; set; }

    #endregion
}