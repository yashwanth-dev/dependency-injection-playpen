using System.Security.Claims;
using System.Security.Principal;
using DI.Console;
using Microsoft.Extensions.Configuration;

public class Program
{
    static void Main(string[] args)
    {
        string message = "Hello DI!";
        IMessageWriter writer = GetMessageWriter();
        string authenticationType = "Custom";
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, "John Doe"),
            new(ClaimTypes.Email, "john.doe@example.com")
        };
        var identity = new ClaimsIdentity(claims, authenticationType);
        IMessageWriter secureMessageWriter = new SecureMessageWriter(writer, identity);
        var salutation = new Salutation(secureMessageWriter);
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