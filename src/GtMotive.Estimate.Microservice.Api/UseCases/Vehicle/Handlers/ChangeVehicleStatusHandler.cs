using System;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.Requests;
using GtMotive.Estimate.Microservice.ApplicationCore.Interfaces;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.Handlers
{
    public class ChangeVehicleStatusHandler
    {
        private readonly IVehicleUseCase _vehicleUseCase;

        public ChangeVehicleStatusHandler(IVehicleUseCase vehicleUseCase)
        {
            _vehicleUseCase = vehicleUseCase;
        }

        public void Handle(int id, ChangeVehicleStatusRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            _vehicleUseCase.ChangeVehicleStatus(id, request.Status);
        }
    }
}
