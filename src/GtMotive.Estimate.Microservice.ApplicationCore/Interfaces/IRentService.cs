using GtMotive.Estimate.Microservice.Domain.Models;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Interfaces
{
    /// <summary>
    /// Defines the service for managing rental operations.
    /// </summary>
    public interface IRentService
    {
        /// <summary>
        /// Retrieves a rent by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the rent.</param>
        /// <returns>The rent associated with the specified identifier.</returns>
        Rent GetRent(int id);

        /// <summary>
        /// Creates a new rent.
        /// </summary>
        /// <param name="rent">The rent to be created.</param>
        void NewRent(Rent rent);

        /// <summary>
        /// Marks a rent as finished.
        /// </summary>
        /// <param name="id">The unique identifier of the rent to be finished.</param>
        void FinishRent(int id);
    }
}
