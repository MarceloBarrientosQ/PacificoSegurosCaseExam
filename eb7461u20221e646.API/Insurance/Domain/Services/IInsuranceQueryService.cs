
using eb7461u20221e646.API.Insurance.Domain.Model.Aggregate;
using eb7461u20221e646.API.Insurance.Domain.Model.Queries;

public interface IInsuranceQueryService
{
    // <summary>
    // Handles the GetAllInsurances query to retrieve all insurances.
    // </summary>
    // <param name="query">The query to get all insurances.</param>
    // <returns>A task that represents the asynchronous operation. The task result contains an enumerable of all insurances.</returns>
    
    // **public Task<IEnumerable<Insurance>> Handle(GetAllInsurance query) **
    
    
    // <summary>
    // Handles the GetInsuranceById query to retrieve a specific insurance by its identifier.
    // </summary>
    // <param name="query">The query containing the identifier of the insurance to retrieve.</
    // <returns>A task that represents the asynchronous operation. The task result contains the insurance with the specified identifier.</returns>
    public Task<Insurance> Handle(GetInsuranceById query); 
    
    
    // <summary>
    // Handles the GetInsuranceByCategory query to retrieve insurances by category.
    // </summary>
    // <param name="query">The query containing the category to filter insurances.</param>
    // <returns>A task that represents the asynchronous operation. The task result contains an enumerable of insurances matching the specified category.</returns>
    
    public Task<IEnumerable<Insurance>> Handle(GetInsuranceByCategory query);
    
}