using System;
using GtMotive.Estimate.Microservice.Api.UseCases.Rent.Requests;
using GtMotive.Estimate.Microservice.ApplicationCore.Interfaces;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rent.Handlers
{
    /// <summary>
    /// Handler for finishing a rent.
    /// </summary>
    public class FinishRentHandler
    {
        private readonly IRentUseCase _rentUseCase;

        /// <summary>
        /// Initializes a new instance of the <see cref="FinishRentHandler"/> class.
        /// </summary>
        /// <param name="rentUseCase">The rent use case.</param>
        public FinishRentHandler(IRentUseCase rentUseCase)
        {
            _rentUseCase = rentUseCase;
        }

        /// <summary>
        /// Handles the finish rent request.
        /// </summary>
        /// <param name="request">The finish rent request.</param>
        /// <exception cref="ArgumentNullException">Thrown when the request is null.</exception>
        public void Handle(FinishRentRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            _rentUseCase.FinishRent(request.Id);
        }
    }
}
