using System;
using GtMotive.Estimate.Microservice.Domain.Models;
using Mongo2Go;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb
{
    public class MongoDbContext : IDisposable
    {
        private readonly MongoDbRunner _runner;
        private readonly IMongoDatabase _database;
        private bool _disposed;

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
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _runner?.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
