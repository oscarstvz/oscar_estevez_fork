using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Dtos;
using System.Collections.ObjectModel;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Interfaces
{
    public interface IVehicleUseCase
    {
        VehicleOutputDto GetVehicle(int id);

        ReadOnlyCollection<VehicleOutputDto> GetAllAvailableVehicles();

        void AddVehicle(AddVehicleInputDto vehicleDto);

        void DeleteVehicle(int id);

        void ChangeVehicleStatus(int id, string status);
    }
}
