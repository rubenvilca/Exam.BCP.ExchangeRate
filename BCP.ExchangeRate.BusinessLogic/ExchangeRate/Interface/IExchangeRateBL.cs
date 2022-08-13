using BCP.ExchangeRate.Domain.ExchangeRate;
using System.Threading.Tasks;

namespace BCP.ExchangeRate.BusinessLogic.ExchangeRate.Interface
{
    public interface IExchangeRateBL
    {
        Task<GetExchangeRate> GetAsync(string originCurrency, string destinationCurrency, decimal amount);

        Task InsertAsync(PostExchangeRate entity);
    }
}