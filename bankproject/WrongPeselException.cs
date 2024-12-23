namespace bankproject;

public class WrongPeselException : Exception
{
    private string message;

    public WrongPeselException(string message)
    {
        this.message = message;
    }
}