namespace DI.Console.Tests;

public class SalutationTests
{
    [Fact]
    public void ExclaimWillWriteCorrectMessageToMessageWriter()
    {
        var writer = new SpyMessageWriter();
        string message = "Hello DI!";
        var sut = new Salutation(writer);
        sut.Exclaim(message);
        Assert.Equal(expected: message, actual: writer.WrittenMessage);
    }
}

public class SpyMessageWriter : IMessageWriter
{
    public string WrittenMessage { get; private set; }
    
    public void Write(string message)
    {
        this.WrittenMessage += message;
    }
}