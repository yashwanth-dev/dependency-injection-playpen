using System.Security.Principal;

namespace DI.Console;

public class SecureMessageWriter: IMessageWriter
{
    private readonly IMessageWriter _writer;
    private readonly IIdentity _identity;

    public SecureMessageWriter(IMessageWriter writer, IIdentity identity)
    {
        _writer = writer ?? throw new ArgumentNullException(nameof(writer));
        _identity = identity ?? throw new ArgumentNullException(nameof(identity));
    }
    
    public void Write(string message)
    {
        if (_identity.IsAuthenticated)
        {
            _writer.Write(message);
        }
    }
}