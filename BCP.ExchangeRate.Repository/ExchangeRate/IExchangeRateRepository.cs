using BCP.ExchangeRate.Domain.ExchangeRate;
using System.Threading.Tasks;

namespace BCP.ExchangeRate.Repository.ExchangeRate
{
    public interface IExchangeRateRepository
    {
        Task<PostExchangeRate> Get(string originCurrency, string destinationCurrency, decimal amount);
        Task Insert(PostExchangeRate entity);
    }
}