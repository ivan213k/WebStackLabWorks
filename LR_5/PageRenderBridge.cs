public interface IRenderer
{
    string Render(string content);
}

// Concrete Implementors
public class HtmlRenderer : IRenderer
{
    public string Render(string content)
    {
        return $"<html><body>{content}</body></html>";
    }
}

public class JsonRenderer : IRenderer
{
    public string Render(string content)
    {
        return $"{{\"content\": \"{content}\"}}";
    }
}

public class XmlRenderer : IRenderer
{
    public string Render(string content)
    {
        return $"<root>{content}</root>";
    }
}


// Abstraction
public abstract class Page
{
    protected IRenderer Renderer;

    protected Page(IRenderer renderer)
    {
        Renderer = renderer;
    }

    public abstract string DisplayContent();
}

// Refined Abstractions
public class HomePage : Page
{
    public HomePage(IRenderer renderer) : base(renderer)
    {
    }

    public override string DisplayContent()
    {
        return "Welcome to the Home Page";
    }
}

public class AboutPage : Page
{
    public AboutPage(IRenderer renderer) : base(renderer)
    {
    }

    public override string DisplayContent()
    {
        return "About us: Learn more about our company";
    }
}

class Program
{
    static void Main()
    {
        // Using the Bridge pattern to render pages in different formats

        // HTML rendering
        IRenderer htmlRenderer = new HtmlRenderer();
        Page homePageHtml = new HomePage(htmlRenderer);
        Console.WriteLine("HTML Render for Home Page: " + homePageHtml.DisplayContent());

        Console.WriteLine();

        // JSON rendering
        IRenderer jsonRenderer = new JsonRenderer();
        Page aboutPageJson = new AboutPage(jsonRenderer);
        Console.WriteLine("JSON Render for About Page: " + aboutPageJson.DisplayContent());

        Console.WriteLine();

        // XML rendering
        IRenderer xmlRenderer = new XmlRenderer();
        Page homePageXml = new HomePage(xmlRenderer);
        Console.WriteLine("XML Render for Home Page: " + homePageXml.DisplayContent());
    }
}