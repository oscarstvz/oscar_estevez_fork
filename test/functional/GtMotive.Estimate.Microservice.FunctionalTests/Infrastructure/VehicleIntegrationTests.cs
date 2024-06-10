using System;
using GtMotive.Estimate.Microservice.ApplicationCore.Services;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Dtos;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using Mongo2Go;
using MongoDB.Driver;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure
{
    /// <summary>
    /// Integration tests for the Vehicle functionality.
    /// Implements IDisposable to ensure proper resource management.
    /// </summary>
    public class VehicleIntegrationTests : IDisposable
    {
        private readonly MongoDbRunner _runner;
        private readonly MongoDbContext _context;
        private readonly VehicleServices _vehicleService;
        private readonly VehicleUseCase _vehicleUseCase;
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleIntegrationTests"/> class.
        /// Sets up the MongoDB runner, context, vehicle service, and use case.
        /// </summary>
        public VehicleIntegrationTests()
        {
            _runner = MongoDbRunner.Start();
            _context = new MongoDbContext();
            _vehicleService = new VehicleServices(_context);
            _vehicleUseCase = new VehicleUseCase(_vehicleService);
        }

        /// <summary>
        /// Tests the addition of a vehicle to the database.
        /// Verifies that the vehicle is correctly added and can be retrieved.
        /// </summary>
        [Fact]
        public void AddVehicleToDatabase()
        {
            var vehicleDto = new AddVehicleInputDto
            {
                Model = "Test Model",
                Year = DateTime.Now,
                LicensePlate = "TEST123",
                DailyRentCost = 100,
                Status = "Available",
                Comments = "Test vehicle"
            };

            _vehicleUseCase.AddVehicle(vehicleDto);

            var addedVehicle = _context.Vehicles.Find(v => v.LicensePlate == "TEST123").FirstOrDefault();
            Assert.NotNull(addedVehicle);
            Assert.Equal("Test Model", addedVehicle.Model);
        }

        /// <summary>
        /// Disposes resources used by the VehicleIntegrationTests class.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged resources and optionally releases managed resources.
        /// </summary>
        /// <param name="disposing">Indicates whether to release managed resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context?.Dispose();
                    _runner?.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
