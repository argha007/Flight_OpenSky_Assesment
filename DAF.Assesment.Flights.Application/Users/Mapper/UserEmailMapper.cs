using DAF.Assesment.Flights.Application.Users.ViewModel;
using DAF.Assesment.Flights.Core.Entities;
namespace DAF.Assesment.Flights.Application.Users.Mapper
{
    public static class UserEmailMapper
    {
        public static UserEmail? MapToEntity(UserEmailViewModel userDetails, int? flightId)
        {
            if (userDetails == null || flightId == null)
            {
                return null;
            }


            return new UserEmail
            {
                FlightId = flightId.Value,
                UserEmail1 = userDetails?.Email ?? string.Empty ,
                NotificationTime = Convert.ToDateTime(userDetails?.NotificationDate).Date 
                    + Convert.ToDateTime(userDetails?.NotificationDate).TimeOfDay,
            };
        }
    }
}
