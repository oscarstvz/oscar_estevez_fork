using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GtMotive.Estimate.Microservice.ApplicationCore.Interfaces;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Dtos;
using GtMotive.Estimate.Microservice.Domain.Models;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases
{
    /// <summary>
    /// Provides use case operations for vehicles.
    /// </summary>
    public class VehicleUseCase : IVehicleUseCase
    {
        private readonly IVehicleService _vehicleService;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleUseCase"/> class.
        /// </summary>
        /// <param name="vehicleService">The vehicle service to be used.</param>
        public VehicleUseCase(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        /// <summary>
        /// Retrieves a vehicle by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the vehicle to retrieve.</param>
        /// <returns>The vehicle with the specified identifier.</returns>
        public VehicleOutputDto GetVehicle(int id)
        {
            var vehicle = _vehicleService.GetVehicle(id);
            if (vehicle == null)
            {
                return null;
            }

            return new VehicleOutputDto
            {
                Id = vehicle.Id,
                Model = vehicle.Model,
                Year = vehicle.Year,
                LicensePlate = vehicle.LicensePlate,
                DailyRentCost = vehicle.DailyRentCost,
                Status = vehicle.Status,
                Comments = vehicle.Comments
            };
        }

        /// <summary>
        /// Retrieves all available vehicles.
        /// </summary>
        /// <returns>A read-only collection of available vehicles.</returns>
        public ReadOnlyCollection<VehicleOutputDto> GetAllAvailableVehicles()
        {
            var vehicles = _vehicleService.GetAllAvailableVehicles()
                .Select(vehicle => new VehicleOutputDto
                {
                    Id = vehicle.Id,
                    Model = vehicle.Model,
                    Year = vehicle.Year,
                    LicensePlate = vehicle.LicensePlate,
                    DailyRentCost = vehicle.DailyRentCost,
                    Status = vehicle.Status,
                    Comments = vehicle.Comments
                }).ToList();

            return new ReadOnlyCollection<VehicleOutputDto>(vehicles);
        }

        /// <summary>
        /// Adds a new vehicle to the collection.
        /// </summary>
        /// <param name="vehicleDto">The vehicle to be added.</param>
        public void AddVehicle(AddVehicleInputDto vehicleDto)
        {
            var vehicle = new Vehicle
            {
                Model = vehicleDto.Model,
                Year = vehicleDto.Year,
                LicensePlate = vehicleDto.LicensePlate,
                DailyRentCost = vehicleDto.DailyRentCost,
                Status = vehicleDto.Status
            };

            _vehicleService.AddVehicle(vehicle);
        }

        /// <summary>
        /// Deletes a vehicle by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the vehicle to delete.</param>
        public void DeleteVehicle(int id)
        {
            _vehicleService.DeleteVehicle(id);
        }

        /// <summary>
        /// Removes all vehicles from the fleet that are older than 5 years.
        /// </summary>
        public void RemoveOldVehicles()
        {
            _vehicleService.RemoveOldVehicles();
        }

        /// <summary>
        /// Changes the status of a vehicle.
        /// </summary>
        /// <param name="id">The identifier of the vehicle whose status is to be changed.</param>
        /// <param name="status">The new status of the vehicle.</param>
        public void ChangeVehicleStatus(int id, string status)
        {
            _vehicleService.ChangeVehicleStatus(id, status);
        }
    }

}
