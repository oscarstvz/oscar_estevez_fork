using GtMotive.Estimate.Microservice.ApplicationCore.Interfaces;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Dtos;
using GtMotive.Estimate.Microservice.Domain.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GtMotive.Estimate.Microservice.UnitTests
{
    public class VehicleUseCaseTests
    {
        private Mock<IVehicleService> _mockVehicleService;
        private VehicleUseCase _vehicleUseCase;

        [SetUp]
        public void Setup()
        {
            _mockVehicleService = new Mock<IVehicleService>();
            _vehicleUseCase = new VehicleUseCase(_mockVehicleService.Object);
        }

        [Test]
        public void GetVehicleTest()
        {
            var vehicle = new Vehicle { Id = 1, Model = "Test", Year = DateTime.Today, LicensePlate = "C9276CF", DailyRentCost = 100, Status = "Available", Comments = "Test" };
            _mockVehicleService.Setup(x => x.GetVehicle(1)).Returns(vehicle);

            var result = _vehicleUseCase.GetVehicle(1);

            Assert.NotNull(result);
            Assert.AreEqual(vehicle.Id, result.Id);
        }

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

        [Test]
        public void AddVehicleTest()
        {
            var vehicleDto = new AddVehicleInputDto { Model = "Test", Year = DateTime.Today, LicensePlate = "C9276CF", DailyRentCost = 100, Status = "Available" };

            _vehicleUseCase.AddVehicle(vehicleDto);

            _mockVehicleService.Verify(x => x.AddVehicle(It.Is<Vehicle>(v => v.Model == vehicleDto.Model && v.Year == vehicleDto.Year && v.LicensePlate == vehicleDto.LicensePlate)), Times.Once);
        }

        [Test]
        public void DeleteVehicleTest()
        {
            _vehicleUseCase.DeleteVehicle(1);

            _mockVehicleService.Verify(x => x.DeleteVehicle(1), Times.Once);
        }

        [Test]
        public void ChangeVehicleStatusTest()
        {
            _vehicleUseCase.ChangeVehicleStatus(1, "Rented");

            _mockVehicleService.Verify(x => x.ChangeVehicleStatus(1, "Rented"), Times.Once);
        }
    }
}
