using System.Collections.ObjectModel;
using GtMotive.Estimate.Microservice.ApplicationCore.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Models;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IMongoCollection<Vehicle> _vehicles;

        public VehicleService(MongoDbContext context)
        {
            _vehicles = context.Vehicles;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _vehicles.InsertOne(vehicle);
        }

        public Vehicle GetVehicle(int id) => _vehicles.Find(vehicle => vehicle.Id == id).FirstOrDefault();

        public ReadOnlyCollection<Vehicle> GetAllAvailableVehicles()
        {
            var vehicles = _vehicles.Find(vehicle => vehicle.Status == "Available").ToList();
            return new ReadOnlyCollection<Vehicle>(vehicles);
        }

        public void DeleteVehicle(int id) => _vehicles.DeleteOne(vehicle => vehicle.Id == id);

        public void ChangeVehicleStatus(int id, string status)
        {
            var update = Builders<Vehicle>.Update.Set(vehicle => vehicle.Status, status);
            _vehicles.UpdateOne(vehicle => vehicle.Id == id, update);
        }
    }
}
