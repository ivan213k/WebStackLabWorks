// Visitor interface
public interface IVisitor
{
    void VisitManager(Manager manager);
    void VisitEngineer(Engineer engineer);
}

// Element interface
public interface IEmployee
{
    void Accept(IVisitor visitor);
}

// Concrete element: Manager
public class Manager : IEmployee
{
    public string Name { get; set; }
    public int Bonus { get; set; }

    public Manager(string name, int bonus)
    {
        Name = name;
        Bonus = bonus;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitManager(this);
    }
}

// Concrete element: Engineer
public class Engineer : IEmployee
{
    public string Name { get; set; }
    public int WorkExperience { get; set; }

    public Engineer(string name, int workExperience)
    {
        Name = name;
        WorkExperience = workExperience;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitEngineer(this);
    }
}

// Concrete visitor: SalaryCalculator
public class SalaryCalculator : IVisitor
{
    public void VisitManager(Manager manager)
    {
        Console.WriteLine($"Calculating salary for Manager {manager.Name}: Base Salary + Bonus = {1000 + manager.Bonus}");
    }

    public void VisitEngineer(Engineer engineer)
    {
        Console.WriteLine($"Calculating salary for Engineer {engineer.Name}: Base Salary + Experience Bonus = {800 + engineer.WorkExperience * 20}");
    }
}
// Client code
class Program
{
    static void Main()
    {
        // Using the Visitor pattern to perform operations on employees

        List<IEmployee> employees = new List<IEmployee>
        {
            new Manager("John", 500),
            new Engineer("Alice", 3),
            new Engineer("Bob", 5)
        };

        // Applying the SalaryCalculator visitor to calculate salaries
        IVisitor salaryCalculator = new SalaryCalculator();

        foreach (var employee in employees)
        {
            employee.Accept(salaryCalculator);
        }
    }
}