using GtMotive.Estimate.Microservice.Domain.Models;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Interfaces
{
    public interface IRentService
    {
        Rent GetRent(int id);

        void NewRent(Rent rent);

        void FinishRent(int id);
    }
}
