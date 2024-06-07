using System;
using MongoDB.Driver;
using Mongo2Go;
using GtMotive.Estimate.Microservice.Domain.Models;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDB
{
    public class MongoDbContext : IDisposable
    {
        private readonly MongoDbRunner _runner;
        private readonly IMongoDatabase _database;

        public MongoDbContext()
        {
            _runner = MongoDbRunner.Start();
            var client = new MongoClient(_runner.ConnectionString);
            _database = client.GetDatabase("RentalDatabase");

            if (!_database.ListCollectionNames().ToList().Contains("Rents"))
            {
                _database.CreateCollection("Rents");
            }

            if (!_database.ListCollectionNames().ToList().Contains("Vehicles"))
            {
                _database.CreateCollection("Vehicles");
            }
        }

        public IMongoCollection<Rent> Rents => _database.GetCollection<Rent>("Rents");
        public IMongoCollection<Vehicle> Vehicles => _database.GetCollection<Vehicle>("Vehicles");

        public void Dispose()
        {
            _runner.Dispose();
        }
    }
}
