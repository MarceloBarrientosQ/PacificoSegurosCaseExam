using eb7461u20221e646.API.Sinister.Domain.Model.ValueObjects;

namespace eb7461u20221e646.API.Sinister.Domain.Model.Aggregate;

public partial class Sinister
{
    public int SinisterId { get; private set; }
    
    public CustomerId CustomerId { get; private set; }
    
    public InsuranceId InsuranceId { get; private set; }
    
    public ESinisterType SinisterType { get; private set; }
    
    // DateAt
    public DateOnly DateAt { get; private set; }
    
    public DateTimeOffset? CreatedAt { get; private set; }
    
    public DateTimeOffset? UpdatedAt { get; private set; }
   
    protected Sinister() {}

    public Sinister(
        CustomerId customerId,
        InsuranceId insuranceId,
        ESinisterType type
        
        )
    {
        CustomerId = customerId;
        InsuranceId = insuranceId;
        SinisterType = type;
        DateAt = DateOnly.FromDateTime(DateTime.Now); 
    }
}