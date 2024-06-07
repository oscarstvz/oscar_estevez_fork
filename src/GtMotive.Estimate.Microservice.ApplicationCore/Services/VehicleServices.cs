using MongoDB.Driver;
using GtMotive.Estimate.Microservice.ApplicationCore.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Models;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Services
{
    public class VehicleServices : IVehicleService
    {
        private readonly IMongoCollection<Vehicle> _vehicles;

        public VehicleServices(MongoDbContext context)
        {
            _vehicles = context.Vehicles;
        }

        public List<Vehicle> GetAllAvailableVehicles() => _vehicles.Find(v => v.Status == "Available").ToList();

        public Vehicle GetVehicle(int id) => _vehicles.Find(v => v.Id == id).FirstOrDefault();

        public void AddVehicle(Vehicle vehicle) => _vehicles.InsertOne(vehicle);

        public void DeleteVehicle(int id) => _vehicles.DeleteOne(v => v.Id == id);

        public void ChangeVehicleStatus(int id, string status)
        {
            var vehicle = _vehicles.Find(v => v.Id == id).FirstOrDefault();
            if (vehicle != null)
            {
                vehicle.Status = status;
                _vehicles.ReplaceOne(v => v.Id == id, vehicle);
            }
        }
    }
}
