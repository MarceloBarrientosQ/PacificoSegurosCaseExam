namespace eb7461u20221e646.API.Insurance.Domain.Model.ValueObjects;

public record Category
{
    public string Value { get; }
    
    private static readonly HashSet<string> ValidValues = new()
    {
        "Personal Insurance",
        "General Insurance",
        "Corporate Insurance"
    };
    
    public Category(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Category cannot be empty.");

        if (!ValidValues.Contains(value))
            throw new ArgumentException($"Invalid category: {value}");

        Value = value;
    }

    public override string ToString() => Value;
}