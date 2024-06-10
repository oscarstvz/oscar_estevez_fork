using System;
using System.Collections.ObjectModel;
using GtMotive.Estimate.Microservice.ApplicationCore.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Models;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Services
{
    /// <summary>
    /// Provides services for managing vehicles in the system.
    /// </summary>
    public class VehicleServices : IVehicleService
    {
        private readonly IMongoCollection<Vehicle> _vehicles;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleServices"/> class.
        /// </summary>
        /// <param name="context">The MongoDB context used to access the vehicle fleet.</param>
        public VehicleServices(IMongoDbContext context)
        {
            _vehicles = context.Vehicles;
        }

        /// <summary>
        /// Adds a new vehicle to the fleet.
        /// </summary>
        /// <param name="vehicle">The vehicle to add.</param>
        public void AddVehicle(Vehicle vehicle)
        {
            if (vehicle.Year < DateTime.Now.AddYears(-5))
            {
                throw new InvalidOperationException("The vehicle is more than 5 years old and cannot be added to the fleet.");
            }

            _vehicles.InsertOne(vehicle);
        }

        /// <summary>
        /// Retrieves a vehicle by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the vehicle.</param>
        /// <returns>The vehicle with the specified identifier.</returns>
        public Vehicle GetVehicle(int id) => _vehicles.Find(vehicle => vehicle.Id == id).FirstOrDefault();

        /// <summary>
        /// Retrieves all available vehicles.
        /// </summary>
        /// <returns>A read-only collection of available vehicles.</returns>
        public ReadOnlyCollection<Vehicle> GetAllAvailableVehicles()
        {
            var vehicles = _vehicles.Find(vehicle => vehicle.Status == "Available").ToList();
            return new ReadOnlyCollection<Vehicle>(vehicles);
        }

        /// <summary>
        /// Deletes a vehicle by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the vehicle to delete.</param>
        public void DeleteVehicle(int id) => _vehicles.DeleteOne(vehicle => vehicle.Id == id);

        /// <summary>
        /// Removes all vehicles from the fleet that are older than 5 years.
        /// </summary>
        public void RemoveOldVehicles()
        {
            var filter = Builders<Vehicle>.Filter.Lt(vehicle => vehicle.Year, DateTime.Now.AddYears(-5));
            _vehicles.DeleteMany(filter);
        }


        /// <summary>
        /// Changes the status of a vehicle.
        /// </summary>
        /// <param name="id">The unique identifier of the vehicle.</param>
        /// <param name="status">The new status of the vehicle.</param>
        public void ChangeVehicleStatus(int id, string status)
        {
            var update = Builders<Vehicle>.Update.Set(vehicle => vehicle.Status, status);
            _vehicles.UpdateOne(vehicle => vehicle.Id == id, update);
        }
    }

}
