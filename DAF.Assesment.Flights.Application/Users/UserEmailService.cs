using DAF.Assesment.Flights.Application.Users.Mapper;
using DAF.Assesment.Flights.Application.Users.ViewModel;
using DAF.Assesment.Flights.Core.Flights;
using DAF.Assesment.Flights.Core.Users;

namespace DAF.Assesment.Flights.Application.Users
{
    public class UserEmailService 
    {
        private readonly IUserRepository _userRepository;
        private readonly IFlightRepository _flightRepository;

        public UserEmailService(IUserRepository userRepository, IFlightRepository flightRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _flightRepository = flightRepository ?? throw new ArgumentNullException(nameof(flightRepository));
        }
        public void SaveUserInformation(UserEmailViewModel userEmailDetails)
        {
            //frontend also should have the required field validations as well
            if (userEmailDetails == null)
            {
                throw new ArgumentNullException(nameof(userEmailDetails), "User email details cannot be null.");
            }
            if (string.IsNullOrEmpty(userEmailDetails.FlightName))
            {
                throw new ArgumentNullException(nameof(userEmailDetails.FlightName), "Fligt name cannot be null.");
            }
            var flightDetails = _flightRepository.GetFlightInformationByName(userEmailDetails.FlightName);
            if (flightDetails == null)
            {
                throw new ArgumentNullException(nameof(flightDetails), "Flight Details not present");
            }
            var entityDetails = UserEmailMapper.MapToEntity(userEmailDetails, flightDetails.Id);
            if (entityDetails != null)
            {
                _userRepository.SaveUserEmailInformation(entityDetails);
            }

        }
    }
}
