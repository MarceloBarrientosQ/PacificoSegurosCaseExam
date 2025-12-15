namespace eb7461u20221e646.API.Sinister.Interfaces.ACL;

public interface ISinisterContextFacade
{
    /// <summary>
    /// Creates a new sinister
    /// </summary>
    /// <param name="customerId">Customer identifier</param>
    /// <param name="insuranceId">Insurance identifier</param>
    /// <param name="sinisterType">Type of sinister</param>
    /// <returns>The id of the created sinister, or 0 if failed</returns>
    Task<int> CreateSinister(
        int customerId,
        int insuranceId,
        string sinisterType
    );
}