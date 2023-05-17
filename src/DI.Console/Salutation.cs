namespace DI.Console;

/// <summary>
/// The responsibility of Salutation class is to exclaim the message given to it using IMessageWriter
/// It does not care about where the message is written, how is the writer object created, etc.,
/// </summary>
public class Salutation
{
    private readonly IMessageWriter _writer;

    public Salutation(IMessageWriter writer)
    {
        _writer = writer ?? throw new ArgumentNullException(nameof(writer));
    }

    public void Exclaim(string message)
    {
        _writer.Write(message);
    }
}