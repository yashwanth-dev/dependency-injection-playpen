using DI.Console;

public class Program
{
    static void Main(string[] args)
    {
        string message = "Hello DI!";
        IMessageWriter writer = new ConsoleWriter();
        var salutation = new Salutation(writer);
        salutation.Exclaim(message);
    }
}