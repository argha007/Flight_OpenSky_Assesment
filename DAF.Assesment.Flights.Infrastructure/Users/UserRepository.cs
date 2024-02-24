using DAF.Assesment.Flights.Core.Entities;
using DAF.Assesment.Flights.Core.Users;

namespace DAF.Assesment.Flights.Infrastructure.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly DafAssesmentContext _dbContext;
        public UserRepository(DafAssesmentContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public void SaveUserEmailInformation(UserEmail userEmail)
        {
            if (userEmail == null)
            {
                throw new ArgumentNullException(nameof(userEmail), "userEmail cannot be null.");
            }
            _dbContext.UserEmails.Add(userEmail);
            _dbContext.SaveChanges();
        }
    }
}
