using System;
using GtMotive.Estimate.Microservice.ApplicationCore.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Models;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Services
{
    /// <summary>
    /// Provides services for managing rent operations.
    /// </summary>
    public class RentServices : IRentService
    {
        private readonly IMongoCollection<Rent> _rents;
        private readonly IMongoCollection<Vehicle> _vehicles;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentServices"/> class with the specified context.
        /// </summary>
        /// <param name="context">The MongoDB context.</param>
        public RentServices(MongoDbContext context)
        {
            _rents = context.Rents;
            _vehicles = context.Vehicles;
        }

        /// <summary>
        /// Retrieves a rent by its ID.
        /// </summary>
        /// <param name="id">The ID of the rent.</param>
        /// <returns>The rent object if found; otherwise, null.</returns>
        public Rent GetRent(int id) => _rents.Find(r => r.Id == id).FirstOrDefault();

        /// <summary>
        /// Creates a new rent.
        /// </summary>
        /// <param name="rent">The rent object to create.</param>
        /// <exception cref="InvalidOperationException">Thrown when the client already has an active rent or the vehicle is more than 5 years old.</exception>
        public void NewRent(Rent rent)
        {
            var activeRent = _rents.Find(r => r.ClientId == rent.ClientId && r.Status == "Booked").FirstOrDefault();
            if (activeRent != null)
            {
                throw new InvalidOperationException("The client already has an active rent.");
            }

            var vehicle = _vehicles.Find(v => v.Id == rent.CarId).FirstOrDefault();
            if (vehicle == null || vehicle.Year < DateTime.Now.AddYears(-5))
            {
                throw new InvalidOperationException("The vehicle is more than 5 years old and cannot be rented.");
            }

            _rents.InsertOne(rent);
        }

        /// <summary>
        /// Finishes a rent by its ID.
        /// </summary>
        /// <param name="id">The ID of the rent.</param>
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
