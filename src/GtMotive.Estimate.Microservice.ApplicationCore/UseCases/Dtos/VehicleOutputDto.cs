using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Dtos
{
    /// <summary>
    /// Represents the data transfer object for vehicle output.
    /// </summary>
    public class VehicleOutputDto
    {
        /// <summary>
        /// Gets or sets the identifier of the vehicle.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the model of the vehicle.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the manufacturing year of the vehicle.
        /// </summary>
        public DateTime Year { get; set; }

        /// <summary>
        /// Gets or sets the license plate of the vehicle.
        /// </summary>
        public string LicensePlate { get; set; }

        /// <summary>
        /// Gets or sets the daily rent cost of the vehicle.
        /// </summary>
        public decimal DailyRentCost { get; set; }

        /// <summary>
        /// Gets or sets the status of the vehicle.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the comments associated with the vehicle.
        /// </summary>
        public string Comments { get; set; }
    }

}
