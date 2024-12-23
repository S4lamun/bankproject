namespace bankproject;

public class WrongAmountException : Exception
{
    private string message;

    public WrongAmountException(string message)
    {
        this.message = message;
    }
}