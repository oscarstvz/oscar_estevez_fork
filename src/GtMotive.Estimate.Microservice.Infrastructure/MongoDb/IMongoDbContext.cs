using GtMotive.Estimate.Microservice.Domain.Models;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb
{
    public interface IMongoDbContext
    {
        IMongoCollection<Rent> Rents { get; }

        IMongoCollection<Vehicle> Vehicles { get; }
    }
}
