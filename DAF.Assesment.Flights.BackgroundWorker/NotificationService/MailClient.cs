using DAF.Assesment.Flights.Utilities;
using System.Net.Mail;

namespace DAF.Assesment.Flights.BackgroundWorker.NotificationService
{
    public class MailClient: INotificationService
    {
        public async Task SendNotification()
        {
            try
            {
                MailAddress from = new("DAF.Assesment.Flight@test.com", "DAFFlightAssement");
                //Here we will write logic to go through the database
                // Fetch User Email Id Flight Details where HasNotified is false/0
                //Go Through the Table and Calculate the Estimated Time
                //If Estimated Time for the Provided Flight is within 15 minutes comparing with DateTime.Now.Minutes(+15)
                //Shoot User Email
                MailAddress to = new("argha.ece@gmail.com", "Argha Guha Biswas");
                var mailMessage = new MailMessage(from, to);

                // set subject and encoding
                mailMessage.Subject = Constants.BackgroundWorker.EmailTemplate.EmailTitle; // Replace value of Flight Number from database
                mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                mailMessage.Body = Constants.BackgroundWorker.EmailTemplate.EmailTitle; // Replace value of the placeholders from database
                mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                mailMessage.IsBodyHtml = true;

                using var smtpClient = new SmtpClient("smtp4dev.net");
                await smtpClient.SendMailAsync(mailMessage);

                //Once email sent succesfully we will update the boolean flag of the UserEmail Table's HasNotified column to True/1
            }

            catch 
            {
                // Digest exception since Not to disturb the other jobs since its test code
            }
        }
    }
}
