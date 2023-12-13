// Mediator interface
public interface IDeliveryMediator
{
    void Notify(object sender, string message);
}

// Concrete mediator
public class DeliveryMediator : IDeliveryMediator
{
    public Customer Customer { get; set; }
    public Warehouse Warehouse { get; set; }
    public Courier Courier { get; set; }

    public void Notify(object sender, string message)
    {
        if (sender is Customer)
        {
            Console.WriteLine($"Customer sends message: {message}");
            Warehouse.HandleNotification(message);
        }
        else if (sender is Warehouse)
        {
            Console.WriteLine($"Warehouse sends message: {message}");
            Courier.HandleNotification(message);
        }
        else if (sender is Courier)
        {
            Console.WriteLine($"Courier sends message: {message}");
            Customer.HandleNotification(message);
        }
    }
}
// Colleague interface
public abstract class DeliveryParticipant
{
    protected IDeliveryMediator Mediator;

    public DeliveryParticipant(IDeliveryMediator mediator)
    {
        Mediator = mediator;
    }

    public abstract void Send(string message);
    public abstract void HandleNotification(string message);
}

// Concrete colleagues
public class Customer : DeliveryParticipant
{
    public Customer(IDeliveryMediator mediator) : base(mediator) { }

    public override void Send(string message)
    {
        Console.WriteLine("Customer sends a message to the mediator.");
        Mediator.Notify(this, message);
    }

    public override void HandleNotification(string message)
    {
        Console.WriteLine($"Customer receives notification: {message}");
    }
}

public class Warehouse : DeliveryParticipant
{
    public Warehouse(IDeliveryMediator mediator) : base(mediator) { }

    public override void Send(string message)
    {
        Console.WriteLine("Warehouse sends a message to the mediator.");
        Mediator.Notify(this, message);
    }

    public override void HandleNotification(string message)
    {
        Console.WriteLine($"Warehouse receives notification: {message}");
    }
}

public class Courier : DeliveryParticipant
{
    public Courier(IDeliveryMediator mediator) : base(mediator) { }

    public override void Send(string message)
    {
        Console.WriteLine("Courier sends a message to the mediator.");
        Mediator.Notify(this, message);
    }

    public override void HandleNotification(string message)
    {
        Console.WriteLine($"Courier receives notification: {message}");
    }
}
class Program
{
    static void Main()
    {
        // Using the Mediator pattern for a delivery system

        IDeliveryMediator mediator = new DeliveryMediator();

        Customer customer = new Customer(mediator);
        Warehouse warehouse = new Warehouse(mediator);
        Courier courier = new Courier(mediator);

        mediator.Customer = customer;
        mediator.Warehouse = warehouse;
        mediator.Courier = courier;

        customer.Send("Request for delivery");
        warehouse.Send("Package ready for pickup");
        courier.Send("On the way to deliver");
    }
}