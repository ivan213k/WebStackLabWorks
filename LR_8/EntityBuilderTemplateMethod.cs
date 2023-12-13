// Abstract base class with template method
public abstract class EntityBuilder
{
    // Template method defining the algorithm
    public void BuildEntity()
    {
        Console.WriteLine("Building entity...");

        BuildCommonPart();
        BuildSpecificPart();

        Console.WriteLine("Entity built.");
    }

    // Abstract method to be implemented by subclasses
    protected abstract void BuildSpecificPart();

    // Common method implemented in the base class
    private void BuildCommonPart()
    {
        Console.WriteLine("Building common part...");
    }
}
// Concrete entity builder
public class ConcreteEntityBuilder : EntityBuilder
{
    // Implementation of the specific part for this entity
    protected override void BuildSpecificPart()
    {
        Console.WriteLine("Building specific part for ConcreteEntity...");
    }
}

class Program
{
    static void Main()
    {
        // Using the Template Method pattern for building entities

        // Using the concrete entity builder
        EntityBuilder entityBuilder = new ConcreteEntityBuilder();
        entityBuilder.BuildEntity();
    }
}