using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces;
using GtMotive.Estimate.Microservice.Api.UseCases.Rent.Requests;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rent.Handlers
{
    public class FinishRentHandler
    {
        private readonly IRentUseCase _rentUseCase;

        public FinishRentHandler(IRentUseCase rentUseCase)
        {
            _rentUseCase = rentUseCase;
        }

        public void Handle(FinishRentRequest request)
        {
            _rentUseCase.FinishRent(request.RentId);
        }
    }
}
