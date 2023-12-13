// representing the standard message sender
public interface IMessageSender
{
    void SendMessage(string message);
}

// Adaptee: Legacy message sender
public class LegacyMessageSender
{
    public void Send(string text)
    {
        Console.WriteLine($"Legacy Message Sent: {text}");
    }
}
// Adapter
public class LegacyMessageSenderAdapter : IMessageSender
{
    private readonly LegacyMessageSender _legacySender;

    public LegacyMessageSenderAdapter(LegacyMessageSender legacySender)
    {
        _legacySender = legacySender;
    }

    public void SendMessage(string message)
    {
        // Adapt the method to fit the IMessageSender interface
        _legacySender.Send(message);
    }
}

// Client code using the IMessageSender interface
public class Client
{
    private readonly IMessageSender _messageSender;

    public Client(IMessageSender messageSender)
    {
        _messageSender = messageSender;
    }

    public void SendMessage(string message)
    {
        _messageSender.SendMessage(message);
    }
}

class Program
{
    static void Main()
    {
        // Using the MessageSender
        IMessageSender messageSender = new MessageSender();
        Client clientWithMessageSender = new Client(messageSender);
        clientWithMessageSender.SendMessage("Hello using MessageSender");

        Console.WriteLine();

        // Using the LegacyMessageSender with the Adapter
        LegacyMessageSender legacyMessageSender = new LegacyMessageSender();
        IMessageSender legacyAdapter = new LegacyMessageSenderAdapter(legacyMessageSender);
        Client clientWithLegacyAdapter = new Client(legacyAdapter);
        clientWithLegacyAdapter.SendMessage("Hello using LegacyMessageSender via Adapter");
    }
}
public class MessageSender : IMessageSender
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Message Sent: {message}");
    }
}