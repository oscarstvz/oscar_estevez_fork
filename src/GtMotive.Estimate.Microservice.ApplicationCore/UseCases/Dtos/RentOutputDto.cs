using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Dtos
{
    /// <summary>
    /// Represents the data transfer object for rent output.
    /// </summary>
    public class RentOutputDto
    {
        /// <summary>
        /// Gets or sets the identifier of the rent.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the car identifier.
        /// </summary>
        public int CarId { get; set; }

        /// <summary>
        /// Gets or sets the start date of the rent.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date of the rent.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the total cost of the rent.
        /// </summary>
        public decimal TotalCost { get; set; }

        /// <summary>
        /// Gets or sets the status of the rent.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the comments associated with the rent.
        /// </summary>
        public string Comments { get; set; }
    }

}
