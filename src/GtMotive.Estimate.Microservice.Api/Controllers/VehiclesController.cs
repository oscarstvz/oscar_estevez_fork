using GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.Handlers;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.Requests;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.Responses;
using GtMotive.Estimate.Microservice.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleUseCase _vehicleUseCase;
        private readonly AddVehicleHandler _addVehicleHandler;
        private readonly ChangeVehicleStatusHandler _changeVehicleStatusHandler;

        public VehiclesController(
            IVehicleUseCase vehicleUseCase,
            AddVehicleHandler addVehicleHandler,
            ChangeVehicleStatusHandler changeVehicleStatusHandler)
        {
            _vehicleUseCase = vehicleUseCase;
            _addVehicleHandler = addVehicleHandler;
            _changeVehicleStatusHandler = changeVehicleStatusHandler;
        }

        [HttpGet("{id}")]
        public ActionResult<VehicleResponse> Get(int id)
        {
            var vehicleDto = _vehicleUseCase.GetVehicle(id);

            if (vehicleDto == null)
            {
                return NotFound();
            }

            var vehicleResponse = new VehicleResponse
            {
                Id = vehicleDto.Id,
                Model = vehicleDto.Model,
                Year = vehicleDto.Year,
                LicensePlate = vehicleDto.LicensePlate,
                DailyRentCost = vehicleDto.DailyRentCost,
                Status = vehicleDto.Status,
                Comments = vehicleDto.Comments
            };

            return vehicleResponse;
        }

        [HttpGet("available")]
        public ActionResult<List<VehicleResponse>> GetAllAvailableVehicles()
        {
            var vehicleDtos = _vehicleUseCase.GetAllAvailableVehicles();
            var vehicleResponses = vehicleDtos
                .Select(dto => new VehicleResponse
                {
                    Id = dto.Id,
                    Model = dto.Model,
                    Year = dto.Year,
                    LicensePlate = dto.LicensePlate,
                    DailyRentCost = dto.DailyRentCost,
                    Status = dto.Status,
                    Comments = dto.Comments
                })
                .ToList();

            return vehicleResponses;
        }

        [HttpPost]
        public ActionResult<VehicleResponse> AddVehicle([FromBody] AddVehicleRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = _addVehicleHandler.Handle(request);
            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        [HttpPut("{id}/status")]
        public IActionResult ChangeVehicleStatus(int id, [FromBody] ChangeVehicleStatusRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _changeVehicleStatusHandler.Handle(id, request);
            return NoContent();
        }
    }
}
