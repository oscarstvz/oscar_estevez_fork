using GtMotive.Estimate.Microservice.ApplicationCore.Interfaces;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Dtos;
using GtMotive.Estimate.Microservice.Domain.Models;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases
{
    /// <summary>
    /// Implementation of the IRentUseCase interface.
    /// </summary>
    public class RentUseCase : IRentUseCase
    {
        private readonly IRentService _rentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentUseCase"/> class.
        /// </summary>
        /// <param name="rentService">The rent service.</param>
        public RentUseCase(IRentService rentService)
        {
            _rentService = rentService;
        }

        /// <summary>
        /// Gets the rent details by ID.
        /// </summary>
        /// <param name="id">The ID of the rent.</param>
        /// <returns>The details of the rent.</returns>
        public RentOutputDto GetRent(int id)
        {
            var rent = _rentService.GetRent(id);
            if (rent == null) return null;

            return new RentOutputDto
            {
                Id = rent.Id,
                ClientId = rent.ClientId,
                CarId = rent.CarId,
                StartDate = rent.StartDate,
                EndDate = rent.EndDate,
                TotalCost = rent.TotalCost,
                Status = rent.Status,
                Comments = rent.Comments
            };
        }

        /// <summary>
        /// Creates a new rent.
        /// </summary>
        /// <param name="rentDto">The details of the new rent.</param>
        public void NewRent(NewRentInputDto rentDto)
        {
            var rent = new Rent
            {
                ClientId = rentDto.ClientId,
                CarId = rentDto.CarId,
                StartDate = rentDto.StartDate,
                EndDate = rentDto.EndDate,
                TotalCost = rentDto.TotalCost,
                Status = "Booked"
            };

            _rentService.NewRent(rent);
        }

        /// <summary>
        /// Finishes a rent by ID.
        /// </summary>
        /// <param name="id">The ID of the rent to finish.</param>
        public void FinishRent(int id)
        {
            _rentService.FinishRent(id);
        }
    }
}
