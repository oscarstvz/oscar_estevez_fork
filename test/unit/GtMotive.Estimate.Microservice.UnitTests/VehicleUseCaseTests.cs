using GtMotive.Estimate.Microservice.ApplicationCore.Interfaces;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Dtos;
using GtMotive.Estimate.Microservice.Domain.Models;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using MongoDB.Driver;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GtMotive.Estimate.Microservice.UnitTests
{
    /// <summary>
    /// Contains unit tests for the VehicleUseCase class.
    /// </summary>
    public class VehicleUseCaseTests
    {
        private Mock<IVehicleService> _mockVehicleService;
        private VehicleUseCase _vehicleUseCase;
        private Mock<IMongoDbContext> _mockContext;

        /// <summary>
        /// Sets up the test environment by initializing mock objects and the VehicleUseCase instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _mockVehicleService = new Mock<IVehicleService>();
            _vehicleUseCase = new VehicleUseCase(_mockVehicleService.Object);

            _mockContext = new Mock<IMongoDbContext>();
            var mockVehicleCollection = new Mock<IMongoCollection<Vehicle>>();
            _mockContext.Setup(c => c.Vehicles).Returns(mockVehicleCollection.Object);
        }

        /// <summary>
        /// Tests the GetVehicle method to ensure it returns the correct vehicle details.
        /// </summary>
        [Test]
        public void GetVehicleTest()
        {
            var vehicle = new Vehicle { Id = 1, Model = "Test", Year = DateTime.Today, LicensePlate = "C9276CF", DailyRentCost = 100, Status = "Available", Comments = "Test" };
            _mockVehicleService.Setup(x => x.GetVehicle(1)).Returns(vehicle);

            var result = _vehicleUseCase.GetVehicle(1);

            Assert.NotNull(result);
            Assert.AreEqual(vehicle.Id, result.Id);
        }

        /// <summary>
        /// Tests the GetAllAvailableVehicles method to ensure it returns the correct list of available vehicles.
        /// </summary>
        [Test]
        public void GetAllAvailableVehiclesTest()
        {
            var vehicles = new List<Vehicle>
        {
            new Vehicle { Id = 1, Model = "Test", Year = DateTime.Today, LicensePlate = "C9276CF", DailyRentCost = 100, Status = "Available", Comments = "Test" }
        };

            var readOnlyVehicles = new ReadOnlyCollection<Vehicle>(vehicles);
            _mockVehicleService.Setup(x => x.GetAllAvailableVehicles()).Returns(readOnlyVehicles);

            var result = _vehicleUseCase.GetAllAvailableVehicles();

            Assert.IsNotNull(result);
            Assert.AreEqual(vehicles.Count, result.Count);
            Assert.AreEqual(vehicles[0].Id, result[0].Id);
        }

        /// <summary>
        /// Tests the AddVehicle method to ensure it correctly adds a new vehicle.
        /// </summary>
        [Test]
        public void AddVehicleTest()
        {
            var vehicleDto = new AddVehicleInputDto { Model = "Test", Year = DateTime.Today, LicensePlate = "C9276CF", DailyRentCost = 100, Status = "Available" };

            _vehicleUseCase.AddVehicle(vehicleDto);

            _mockVehicleService.Verify(x => x.AddVehicle(It.Is<Vehicle>(v => v.Model == vehicleDto.Model && v.Year == vehicleDto.Year && v.LicensePlate == vehicleDto.LicensePlate)), Times.Once);
        }

        /// <summary>
        /// Tests the DeleteVehicle method to ensure it correctly deletes a vehicle.
        /// </summary>
        [Test]
        public void DeleteVehicleTest()
        {
            _vehicleUseCase.DeleteVehicle(1);

            _mockVehicleService.Verify(x => x.DeleteVehicle(1), Times.Once);
        }

        /// <summary>
        /// Tests the ChangeVehicleStatus method to ensure it correctly changes the status of a vehicle.
        /// </summary>
        [Test]
        public void ChangeVehicleStatusTest()
        {
            _vehicleUseCase.ChangeVehicleStatus(1, "Booked");

            _mockVehicleService.Verify(x => x.ChangeVehicleStatus(1, "Booked"), Times.Once);
        }
    }
}
