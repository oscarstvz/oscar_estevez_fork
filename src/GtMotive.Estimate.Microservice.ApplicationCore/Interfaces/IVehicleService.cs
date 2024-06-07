using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Dtos;
using System.Collections.Generic;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces
{
    public interface IVehicleUseCase
    {
        VehicleOutputDto GetVehicle(int id);

        List<VehicleOutputDto> GetAllAvailableVehicles();

        void AddVehicle(AddVehicleInputDto vehicle);

        void DeleteVehicle(int id);

        void ChangeVehicleStatus(int id, string status);
    }
}
