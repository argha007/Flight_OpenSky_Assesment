using DAF.Assesment.Flights.Core.Entities;

namespace DAF.Assesment.Flights.Core.Users
{
    public interface IUserRepository
    {
        void SaveUserEmailInformation(UserEmail userEmail);
    }
}
