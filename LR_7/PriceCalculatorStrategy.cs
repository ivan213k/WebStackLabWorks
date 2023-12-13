// Strategy interface
public interface IPriceCalculationStrategy
{
    decimal CalculatePrice(decimal basePrice);
}

// Concrete strategies
public class RegularPriceStrategy : IPriceCalculationStrategy
{
    public decimal CalculatePrice(decimal basePrice)
    {
        return basePrice;
    }
}
public class DiscountPriceStrategy : IPriceCalculationStrategy
{
    private decimal discountPercentage;

    public DiscountPriceStrategy(decimal discountPercentage)
    {
        this.discountPercentage = discountPercentage;
    }

    public decimal CalculatePrice(decimal basePrice)
    {
        // Discounted price calculation logic
        return basePrice - (basePrice * discountPercentage / 100);
    }
}
// Context class that uses the strategy
public class PriceCalculator
{
    private IPriceCalculationStrategy strategy;

    public PriceCalculator(IPriceCalculationStrategy strategy)
    {
        this.strategy = strategy;
    }

    public void SetStrategy(IPriceCalculationStrategy strategy)
    {
        this.strategy = strategy;
    }

    public decimal CalculateFinalPrice(decimal basePrice)
    {
        // Delegate the price calculation to the selected strategy
        return strategy.CalculatePrice(basePrice);
    }
}

class Program
{
    static void Main()
    {
        // Using the Strategy pattern for price calculation

        // Base price
        decimal basePrice = 100;

        // Using regular price strategy
        IPriceCalculationStrategy regularStrategy = new RegularPriceStrategy();
        PriceCalculator regularPriceCalculator = new PriceCalculator(regularStrategy);
        decimal regularFinalPrice = regularPriceCalculator.CalculateFinalPrice(basePrice);
        Console.WriteLine($"Regular Price: {regularFinalPrice}");

        Console.WriteLine();

        // Using discount price strategy
        IPriceCalculationStrategy discountStrategy = new DiscountPriceStrategy(20);
        PriceCalculator discountPriceCalculator = new PriceCalculator(discountStrategy);
        decimal discountFinalPrice = discountPriceCalculator.CalculateFinalPrice(basePrice);
        Console.WriteLine($"Discounted Price: {discountFinalPrice}");
    }
}