using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GtMotive.Estimate.Microservice.ApplicationCore.Interfaces;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Dtos;
using GtMotive.Estimate.Microservice.Domain.Models;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases
{
    public class VehicleUseCase : IVehicleUseCase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleUseCase(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public VehicleOutputDto GetVehicle(int id)
        {
            var vehicle = _vehicleService.GetVehicle(id);
            if (vehicle == null)
            {
                return null;
            }

            return new VehicleOutputDto
            {
                Id = vehicle.Id,
                Model = vehicle.Model,
                Year = vehicle.Year,
                LicensePlate = vehicle.LicensePlate,
                DailyRentCost = vehicle.DailyRentCost,
                Status = vehicle.Status,
                Comments = vehicle.Comments
            };
        }

        public ReadOnlyCollection<VehicleOutputDto> GetAllAvailableVehicles()
        {
            var vehicles = _vehicleService.GetAllAvailableVehicles()
                .Select(vehicle => new VehicleOutputDto
                {
                    Id = vehicle.Id,
                    Model = vehicle.Model,
                    Year = vehicle.Year,
                    LicensePlate = vehicle.LicensePlate,
                    DailyRentCost = vehicle.DailyRentCost,
                    Status = vehicle.Status,
                    Comments = vehicle.Comments
                }).ToList();

            return new ReadOnlyCollection<VehicleOutputDto>(vehicles);
        }

        public void AddVehicle(AddVehicleInputDto vehicleDto)
        {
            var vehicle = new Vehicle
            {
                Model = vehicleDto.Model,
                Year = vehicleDto.Year,
                LicensePlate = vehicleDto.LicensePlate,
                DailyRentCost = vehicleDto.DailyRentCost,
                Status = vehicleDto.Status
            };

            _vehicleService.AddVehicle(vehicle);
        }

        public void DeleteVehicle(int id)
        {
            _vehicleService.DeleteVehicle(id);
        }

        public void ChangeVehicleStatus(int id, string status)
        {
            _vehicleService.ChangeVehicleStatus(id, status);
        }
    }
}
