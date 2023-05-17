using DI.Console;
using Microsoft.Extensions.Configuration;

public class Program
{
    static void Main(string[] args)
    {
        string message = "Hello DI!";
        IMessageWriter writer = GetMessageWriter();
        var salutation = new Salutation(writer);
        salutation.Exclaim(message);
    }

    static IMessageWriter GetMessageWriter()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();
        string typeName = configuration["messageWriter"];
        Type type = Type.GetType(typeName, throwOnError: true);
        IMessageWriter writer = (IMessageWriter) Activator.CreateInstance(type);
        return writer;
    }
}