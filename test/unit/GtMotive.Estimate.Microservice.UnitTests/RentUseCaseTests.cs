using GtMotive.Estimate.Microservice.ApplicationCore.Interfaces;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Dtos;
using GtMotive.Estimate.Microservice.Domain.Models;
using Moq;
using NUnit.Framework;
using System;

namespace GtMotive.Estimate.Microservice.UnitTests
{
    /// <summary>
    /// Contains unit tests for the RentUseCase class.
    /// </summary>
    public class RentUseCaseTests
    {
        private Mock<IRentService> _mockRentService;
        private RentUseCase _rentUseCase;

        /// <summary>
        /// Sets up the test environment by initializing mock objects and the RentUseCase instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _mockRentService = new Mock<IRentService>();
            _rentUseCase = new RentUseCase(_mockRentService.Object);
        }

        /// <summary>
        /// Tests the GetRent method to ensure it returns the correct rent details.
        /// </summary>
        [Test]
        public void GetRentTest()
        {
            var rent = new Rent { Id = 1, ClientId = "23658914A", CarId = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1), TotalCost = 100, Status = "Booked", Comments = "Test" };
            _mockRentService.Setup(x => x.GetRent(1)).Returns(rent);

            var result = _rentUseCase.GetRent(1);

            Assert.NotNull(result);
            Assert.AreEqual(rent.Id, result.Id);
        }

        /// <summary>
        /// Tests the NewRent method to ensure it correctly creates a new rent.
        /// </summary>
        [Test]
        public void NewRentTest()
        {
            var rentDto = new NewRentInputDto { ClientId = "23658914A", CarId = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1), TotalCost = 100 };

            _rentUseCase.NewRent(rentDto);

            _mockRentService.Verify(x => x.NewRent(It.Is<Rent>(r => r.ClientId == rentDto.ClientId && r.CarId == rentDto.CarId && r.TotalCost == rentDto.TotalCost)), Times.Once);
        }

        /// <summary>
        /// Tests the FinishRent method to ensure it correctly finishes a rent.
        /// </summary>
        [Test]
        public void FinishRentTest()
        {
            _rentUseCase.FinishRent(1);

            _mockRentService.Verify(x => x.FinishRent(1), Times.Once);
        }
    }
}
