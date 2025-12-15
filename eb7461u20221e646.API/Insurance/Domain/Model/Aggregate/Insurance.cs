using eb7461u20221e646.API.Insurance.Domain.Model.ValueObjects;

namespace eb7461u20221e646.API.Insurance.Domain.Model.Aggregate;

public partial class Insurance
{
   
   public int InsuranceId { get; private set; }

   public string Name { get; private set; }

   public Category Category { get; private set; }

   public Subcategory Subcategory { get; private set; }
   
   public DateOnly RegisteredDate { get; private set; }

   public DateTimeOffset? CreatedAt { get; private set; }
  
   public DateTimeOffset? UpdatedAt { get; private set; }
   
   protected Insurance() {}

   public Insurance(string name, Category category, Subcategory subcategory)
   {
      Name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;
      
      Category = category ?? throw  new ArgumentNullException(nameof(category));
      Subcategory = subcategory ?? throw new ArgumentNullException(nameof(subcategory));
      
      RegisteredDate = DateOnly.FromDateTime(DateTime.Now);
   }
   
}