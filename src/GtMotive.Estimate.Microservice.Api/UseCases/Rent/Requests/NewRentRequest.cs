using System;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rent.Requests
{
    public class NewRentRequest
    {
        public string ClientId { get; set; }
        public int CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalCost { get; set; }
    }
}
