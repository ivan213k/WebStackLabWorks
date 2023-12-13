// Interface representing a social network
public interface ISocialNetwork
{
    void LogIn();
    void LogOut();
    void Post(string message);
}
// Concrete implementation for Facebook
public class Facebook : ISocialNetwork
{
    public void LogIn()
    {
        Console.WriteLine("Logging in to Facebook");
    }

    public void LogOut()
    {
        Console.WriteLine("Logging out from Facebook");
    }

    public void Post(string message)
    {
        Console.WriteLine($"Posting on Facebook: {message}");
    }
}

// Concrete implementation for Twitter
public class Twitter : ISocialNetwork
{
    public void LogIn()
    {
        Console.WriteLine("Logging in to Twitter");
    }

    public void LogOut()
    {
        Console.WriteLine("Logging out from Twitter");
    }

    public void Post(string message)
    {
        Console.WriteLine($"Posting on Twitter: {message}");
    }
}
// Concrete factory for creating instances based on string input
public class SocialNetworkFactory
{
    public ISocialNetwork CreateSocialNetwork(string networkType)
    {
        switch (networkType.ToLower())
        {
            case "facebook":
                return new Facebook();
            case "twitter":
                return new Twitter();
            default:
                throw new ArgumentException($"Unsupported social network type: {networkType}");
        }
    }
}
class Program
{
    static void Main()
    {
        // Using the Factory Method with string input to create instances of social networks
        SocialNetworkFactory factory = new SocialNetworkFactory();

        ISocialNetwork facebook = factory.CreateSocialNetwork("Facebook");
        ISocialNetwork twitter = factory.CreateSocialNetwork("Twitter");

        // Using the created instances
        facebook.LogIn();
        facebook.Post("Hello, Facebook!");
        facebook.LogOut();

        Console.WriteLine();

        twitter.LogIn();
        twitter.Post("Hello, Twitter!");
        twitter.LogOut();
    }
}