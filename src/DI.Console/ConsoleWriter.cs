namespace DI.Console;

public class ConsoleWriter: IMessageWriter
{
    public void Write(string message)
    {
        System.Console.WriteLine(message);
    }
}