using BCP.ExchangeRate.BusinessLogic.Interfaces;
using BCP.ExchangeRate.Domain;
using System.Threading.Tasks;

namespace BCP.ExchangeRate.BusinessLogic
{
    public class UserBL : IUserBL
    {
        public UserBL()
        {
        }

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            User credentials = new User("rvilca", "123", "Rubén", "Vilca");

            if (username.Equals(credentials.UserName) && password.Equals(credentials.Password))
                return credentials;

            return null;
        }
    }
}