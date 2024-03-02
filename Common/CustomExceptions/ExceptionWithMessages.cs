namespace Common.CustomExceptions;

public class ExceptionWithMessages(IEnumerable<string> messages) : Exception
{
    public List<string> Messages { get; } = messages.ToList();
}