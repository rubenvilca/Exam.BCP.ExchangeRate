using BCP.ExchangeRate.Domain;
using System.Threading.Tasks;

namespace BCP.ExchangeRate.BusinessLogic.Interfaces
{
    public interface IUserBL
    {
        Task<User> AuthenticateAsync(string username, string password);
    }
}