using System.ComponentModel.DataAnnotations;

namespace DAF.Assesment.Flights.Application.Users.ViewModel
{
    public class UserEmailViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Flight name is required")]
        public string? FlightName { get; set; }

        public DateTime? NotificationDate { get; set; }

        public TimeSpan? NotificationTime { get; set; }
    }

}
