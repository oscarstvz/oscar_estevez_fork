using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.Requests;

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
            _vehicleUseCase.ChangeVehicleStatus(id, request.Status);
        }
    }
}
