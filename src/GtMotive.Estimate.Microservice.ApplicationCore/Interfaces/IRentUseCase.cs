using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Dtos;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Interfaces
{
    /// <summary>
    /// Interface for rent use cases.
    /// </summary>
    public interface IRentUseCase
    {
        /// <summary>
        /// Gets the rent details by ID.
        /// </summary>
        /// <param name="id">The ID of the rent.</param>
        /// <returns>The details of the rent.</returns>
        RentOutputDto GetRent(int id);

        /// <summary>
        /// Creates a new rent.
        /// </summary>
        /// <param name="rentDto">The details of the new rent.</param>
        void NewRent(NewRentInputDto rentDto);

        /// <summary>
        /// Finishes a rent by ID.
        /// </summary>
        /// <param name="id">The ID of the rent to finish.</param>
        void FinishRent(int id);
    }
}
