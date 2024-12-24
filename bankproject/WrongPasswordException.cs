namespace bankproject;

public class WrongPasswordException : Exception
{
    private string message;

    public WrongPasswordException(string message)
    {
        this.message = message;
    }
}