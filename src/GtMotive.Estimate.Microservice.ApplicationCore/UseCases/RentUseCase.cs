using System;
using GtMotive.Estimate.Microservice.ApplicationCore.Interfaces;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Dtos;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Models;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases
{
    public class RentUseCase : IRentUseCase
    {
        private readonly IRentService _rentService;

        public RentUseCase(IRentService rentService)
        {
            _rentService = rentService;
        }

        public RentOutputDto GetRent(int id)
        {
            var rent = _rentService.GetRent(id);
            if (rent == null) return null;

            return new RentOutputDto
            {
                Id = rent.Id,
                ClientId = rent.ClientId,
                CarId = rent.CarId,
                StartDate = rent.StartDate,
                EndDate = rent.EndDate,
                TotalCost = rent.TotalCost,
                Status = rent.Status,
                Comments = rent.Comments
            };
        }

        public void NewRent(NewRentInputDto rentDto)
        {
            var rent = new Rent
            {
                ClientId = rentDto.ClientId,
                CarId = rentDto.CarId,
                StartDate = rentDto.StartDate,
                EndDate = rentDto.EndDate,
                TotalCost = rentDto.TotalCost,
                Status = "Booked"
            };

            _rentService.NewRent(rent);
        }

        public void FinishRent(int id)
        {
            _rentService.FinishRent(id);
        }
    }
}
