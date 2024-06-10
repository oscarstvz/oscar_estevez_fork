using GtMotive.Estimate.Microservice.Domain.Models;
using System.Collections.ObjectModel;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Interfaces
{
    /// <summary>
    /// Defines the interface for vehicle-related operations.
    /// </summary>
    public interface IVehicleService
    {
        /// <summary>
        /// Adds a new vehicle to the collection.
        /// </summary>
        /// <param name="vehicle">The vehicle to be added.</param>
        void AddVehicle(Vehicle vehicle);

        /// <summary>
        /// Retrieves a vehicle by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the vehicle to retrieve.</param>
        /// <returns>The vehicle with the specified identifier.</returns>
        Vehicle GetVehicle(int id);

        /// <summary>
        /// Retrieves all available vehicles.
        /// </summary>
        /// <returns>A read-only collection of available vehicles.</returns>
        ReadOnlyCollection<Vehicle> GetAllAvailableVehicles();

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
