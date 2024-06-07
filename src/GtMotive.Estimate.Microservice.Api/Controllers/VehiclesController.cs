using GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.Requests;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.Responses;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly AddVehicleHandler _addVehicleHandler;
        private readonly ChangeVehicleStatusHandler _changeVehicleStatusHandler;

        public VehiclesController(AddVehicleHandler addVehicleHandler, ChangeVehicleStatusHandler changeVehicleStatusHandler)
        {
            _addVehicleHandler = addVehicleHandler;
            _changeVehicleStatusHandler = changeVehicleStatusHandler;
        }

        [HttpGet("{id}")]
        public ActionResult<VehicleResponse> Get(int id)
        {
            var vehicle = _vehicleUseCase.GetVehicle(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return vehicle;
        }

        [HttpGet("available")]
        public ActionResult<List<VehicleResponse>> GetAllAvailableVehicles()
        {
            var vehicles = _vehicleUseCase.GetAllAvailableVehicles();
            return vehicles;
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
