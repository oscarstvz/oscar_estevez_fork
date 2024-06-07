using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces;
using GtMotive.Estimate.Microservice.Api.UseCases.Rent.Requests;
using GtMotive.Estimate.Microservice.Api.UseCases.Rent.Responses;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Dtos;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rent.Handlers
{
    public class NewRentHandler
    {
        private readonly IRentUseCase _rentUseCase;

        public NewRentHandler(IRentUseCase rentUseCase)
        {
            _rentUseCase = rentUseCase;
        }

        public RentResponse Handle(NewRentRequest request)
        {
            var rentDto = new NewRentInputDto
            {
                ClientId = request.ClientId,
                CarId = request.CarId,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                TotalCost = request.TotalCost
            };

            _rentUseCase.NewRent(rentDto);

            var createdRent = _rentUseCase.GetRent(rentDto.CarId);
            return new RentResponse
            {
                Id = createdRent.Id,
                ClientId = createdRent.ClientId,
                CarId = createdRent.CarId,
                StartDate = createdRent.StartDate,
                EndDate = createdRent.EndDate,
                TotalCost = createdRent.TotalCost,
                Status = createdRent.Status,
                Comments = createdRent.Comments
            };
        }
    }
}
