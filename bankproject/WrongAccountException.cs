namespace bankproject;

public class WrongAccountException : Exception
{
    private string message;

    public WrongAccountException(string message)
    {
        this.message = message;
    }
}