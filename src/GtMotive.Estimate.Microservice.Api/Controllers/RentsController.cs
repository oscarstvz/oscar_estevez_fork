using GtMotive.Estimate.Microservice.Api.UseCases.Rent.Requests;
using GtMotive.Estimate.Microservice.Api.UseCases.Rent.Responses;
using GtMotive.Estimate.Microservice.Api.UseCases.Rent.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentsController : ControllerBase
    {
        private readonly NewRentHandler _newRentHandler;
        private readonly FinishRentHandler _finishRentHandler;

        public RentsController(NewRentHandler newRentHandler, FinishRentHandler finishRentHandler)
        {
            _newRentHandler = newRentHandler;
            _finishRentHandler = finishRentHandler;
        }

        [HttpPost]
        public ActionResult<RentResponse> NewRent([FromBody] NewRentRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = _newRentHandler.Handle(request);
            return CreatedAtAction(nameof(NewRent), new { id = response.Id }, response);
        }

        [HttpPut("{id}/finish")]
        public IActionResult FinishRent(int id, [FromBody] FinishRentRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _finishRentHandler.Handle(request);
            return NoContent();
        }
    }
}
