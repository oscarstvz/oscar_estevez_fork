using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.Requests;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.Responses;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Dtos;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.Handlers
{
    public class AddVehicleHandler
    {
        private readonly IVehicleUseCase _vehicleUseCase;

        public AddVehicleHandler(IVehicleUseCase vehicleUseCase)
        {
            _vehicleUseCase = vehicleUseCase;
        }

        public VehicleResponse Handle(AddVehicleRequest request)
        {
            var vehicleDto = new AddVehicleInputDto
            {
                Model = request.Model,
                Year = request.Year,
                LicensePlate = request.LicensePlate,
                DailyRentCost = request.DailyRentCost,
                Status = request.Status
            };

            _vehicleUseCase.AddVehicle(vehicleDto);

            var createdVehicle = _vehicleUseCase.GetVehicle(vehicleDto.Id);
            return new VehicleResponse
            {
                Id = createdVehicle.Id,
                Model = createdVehicle.Model,
                Year = createdVehicle.Year,
                LicensePlate = createdVehicle.LicensePlate,
                DailyRentCost = createdVehicle.DailyRentCost,
                Status = createdVehicle.Status,
                Comments = createdVehicle.Comments
            };
        }
    }
}
