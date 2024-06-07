using MongoDB.Driver;
using GtMotive.Estimate.Microservice.ApplicationCore.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Models;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Services
{
    public class RentServices : IRentService
    {
        private readonly IMongoCollection<Rent> _rents;

        public RentServices(MongoDbContext context)
        {
            _rents = context.Rents;
        }

        public Rent GetRent(int id) => _rents.Find(r => r.Id == id).FirstOrDefault();

        public void NewRent(Rent rent) => _rents.InsertOne(rent);

        public void FinishRent(int id)
        {
            var rent = _rents.Find(r => r.Id == id).FirstOrDefault();
            if (rent != null)
            {
                rent.Status = "Finished";
                _rents.ReplaceOne(r => r.Id == id, rent);
            }
        }
    }
}
