using GtMotive.Estimate.Microservice.ApplicationCore.Interfaces;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Dtos;
using GtMotive.Estimate.Microservice.Domain.Models;
using Moq;
using NUnit.Framework;
using System;

namespace GtMotive.Estimate.Microservice.UnitTests
{
    public class RentUseCaseTests
    {
        private Mock<IRentService> _mockRentService;
        private RentUseCase _rentUseCase;

        [SetUp]
        public void Setup()
        {
            _mockRentService = new Mock<IRentService>();
            _rentUseCase = new RentUseCase(_mockRentService.Object);
        }

        [Test]
        public void GetRentTest()
        {
            var rent = new Rent { Id = 1, ClientId = "23658914A", CarId = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1), TotalCost = 100, Status = "Booked", Comments = "Test" };
            _mockRentService.Setup(x => x.GetRent(1)).Returns(rent);

            var result = _rentUseCase.GetRent(1);

            Assert.NotNull(result);
            Assert.AreEqual(rent.Id, result.Id);
        }

        [Test]
        public void NewRentTest()
        {
            var rentDto = new NewRentInputDto { ClientId = "23658914A", CarId = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1), TotalCost = 100 };

            _rentUseCase.NewRent(rentDto);

            _mockRentService.Verify(x => x.NewRent(It.Is<Rent>(r => r.ClientId == rentDto.ClientId && r.CarId == rentDto.CarId && r.TotalCost == rentDto.TotalCost)), Times.Once);
        }

        [Test]
        public void FinishRentTest()
        {
            _rentUseCase.FinishRent(1);

            _mockRentService.Verify(x => x.FinishRent(1), Times.Once);
        }
    }
}
