using GtMotive.Estimate.Microservice.Domain.Models;
using System.Collections.ObjectModel;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Interfaces
{
    public interface IVehicleService
    {
        void AddVehicle(Vehicle vehicle);

        Vehicle GetVehicle(int id);

        ReadOnlyCollection<Vehicle> GetAllAvailableVehicles();

        void DeleteVehicle(int id);

        void ChangeVehicleStatus(int id, string status);
    }
}
