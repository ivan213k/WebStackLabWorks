// Product: Represents the SQL query
public class SqlQuery
{
    public string Select { get; set; }
    public string From { get; set; }
    public string Where { get; set; }

    public override string ToString()
    {
        return $"SELECT {Select} FROM {From} WHERE {Where}";
    }
}

// Abstract builder interface
public interface ISqlQueryBuilder
{
    void BuildSelect(string select);
    void BuildFrom(string from);
    void BuildWhere(string where);
    SqlQuery GetQuery();
}

// Concrete builder for MySQL
public class MySqlQueryBuilder : ISqlQueryBuilder
{
    private SqlQuery _query = new SqlQuery();

    public void BuildSelect(string select)
    {
        _query.Select = select;
    }

    public void BuildFrom(string from)
    {
        _query.From = from;
    }

    public void BuildWhere(string where)
    {
        _query.Where = where;
    }

    public SqlQuery GetQuery()
    {
        return _query;
    }
}

// Concrete builder for SQL Server
public class SqlServerQueryBuilder : ISqlQueryBuilder
{
    private SqlQuery _query = new SqlQuery();

    public void BuildSelect(string select)
    {
        _query.Select = select;
    }

    public void BuildFrom(string from)
    {
        _query.From = from;
    }

    public void BuildWhere(string where)
    {
        _query.Where = where;
    }

    public SqlQuery GetQuery()
    {
        return _query;
    }
}

// Director: Constructs an SQL query using the builder interface
public class SqlQueryDirector
{
    public SqlQuery ConstructQuery(ISqlQueryBuilder builder)
    {
        builder.BuildSelect("FirstName, LastName");
        builder.BuildFrom("Users");

        // Example: Add a condition based on the SQL provider
        if (builder is MySqlQueryBuilder)
        {
            builder.BuildWhere("City = 'New York'");
        }
        else if (builder is SqlServerQueryBuilder)
        {
            builder.BuildWhere("City = 'Seattle'");
        }

        return builder.GetQuery();
    }
}
class Program
{
    static void Main()
    {
        // Using the Builder pattern to create SQL queries for different providers
        SqlQueryDirector director = new SqlQueryDirector();

        // MySQL query builder
        ISqlQueryBuilder mySqlBuilder = new MySqlQueryBuilder();
        SqlQuery mySqlQuery = director.ConstructQuery(mySqlBuilder);
        Console.WriteLine("MySQL Query: " + mySqlQuery);

        Console.WriteLine();

        // SQL Server query builder
        ISqlQueryBuilder sqlServerBuilder = new SqlServerQueryBuilder();
        SqlQuery sqlServerQuery = director.ConstructQuery(sqlServerBuilder);
        Console.WriteLine("SQL Server Query: " + sqlServerQuery);
    }
}