using System.Runtime.Serialization;

namespace kolokwium_2.Exceptions;

public class NotFoundException : Exception
{
    private string _message;

    public NotFoundException()
    {
    }

    protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public NotFoundException(string? message) : base(message)
    {
        
    }

    public NotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}