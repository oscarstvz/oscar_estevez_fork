using System;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rent.Responses
{
    public class RentResponse
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public int CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalCost { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
    }
}
