using System.ComponentModel.DataAnnotations.Schema;

namespace eb7461u20221e646.API.Insurance.Domain.Model.ValueObjects;

public record Subcategory
{
    public string Value { get; private set; } = null!;

    [NotMapped]  
    public Category Category { get; private set; } = null!;

    private Subcategory() { }  

    public Subcategory(Category category, string value)
    {
        if (category is null)
            throw new ArgumentNullException(nameof(category));

        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Subcategory cannot be empty.");

        if (!ValidValues.TryGetValue(category.Value, out var subcategories) ||
            !subcategories.Contains(value))
        {
            throw new ArgumentException(
                $"Invalid subcategory '{value}' for category '{category.Value}'.");
        }

        Category = category;
        Value = value;
    }

    private static readonly IReadOnlyDictionary<string, HashSet<string>> ValidValues =
        new Dictionary<string, HashSet<string>>
        {
            ["Personal Insurance"] = new()
            {
                "Life",
                "Health",
                "Personal Accidents",
                "Travel Insurance"
            },
            ["General Insurance"] = new()
            {
                "Vehicular",
                "Home",
                "Business and Companies",
                "Cargo and Logistics"
            },
            ["Corporate Insurance"] = new()
            {
                "Corporate Health",
                "Life Law",
                "Occupational Risks",
                "Comprehensive Risk Management"
            }
        };

    public override string ToString() => Value;
}