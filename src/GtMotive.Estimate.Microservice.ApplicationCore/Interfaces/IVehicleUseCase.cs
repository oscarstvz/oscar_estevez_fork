using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Dtos;
using System.Collections.ObjectModel;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Interfaces
{
    /// <summary>
    /// Defines the interface for vehicle use case operations.
    /// </summary>
    public interface IVehicleUseCase
    {
        /// <summary>
        /// Retrieves a vehicle by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the vehicle to retrieve.</param>
        /// <returns>The vehicle with the specified identifier.</returns>
        VehicleOutputDto GetVehicle(int id);

        /// <summary>
        /// Retrieves all available vehicles.
        /// </summary>
        /// <returns>A read-only collection of available vehicles.</returns>
        ReadOnlyCollection<VehicleOutputDto> GetAllAvailableVehicles();

        /// <summary>
        /// Adds a new vehicle to the collection.
        /// </summary>
        /// <param name="vehicleDto">The vehicle to be added.</param>
        void AddVehicle(AddVehicleInputDto vehicleDto);

        /// <summary>
        /// Deletes a vehicle by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the vehicle to delete.</param>
        void DeleteVehicle(int id);

        /// <summary>
        /// Removes vehicles that are older than 5 years from the fleet.
        /// </summary>
        void RemoveOldVehicles();

        /// <summary>
        /// Changes the status of a vehicle.
        /// </summary>
        /// <param name="id">The identifier of the vehicle whose status is to be changed.</param>
        /// <param name="status">The new status of the vehicle.</param>
        void ChangeVehicleStatus(int id, string status);
    }
}
