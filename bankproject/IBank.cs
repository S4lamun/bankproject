namespace bankproject;

internal interface IBank
{
    public void AddAccount(Account account);
    public void RemoveAccount(Account account);
    public string DisplayAllAccounts();
    public decimal SumAllBalance();
    public Account FindAccount(long accountNumber);

    public Account? FindAccount(string password);
    public string DisplayAllEmployess();
}