using BCP.ExchangeRate.BusinessLogic.ExchangeRate.Interface;
using BCP.ExchangeRate.Domain.ExchangeRate;
using BCP.ExchangeRate.Repository.ExchangeRate;
using System;
using System.Threading.Tasks;

namespace BCP.ExchangeRate.BusinessLogic.ExchangeRate
{
    public class ExchangeRateBL : IExchangeRateBL
    {
        private readonly IExchangeRateRepository _exchangeRateRepository;

        public ExchangeRateBL(IExchangeRateRepository exchangeRateRepository)
        {
            _exchangeRateRepository = exchangeRateRepository;
        }

        public async Task<GetExchangeRate> GetAsync(string originCurrency, string destinationCurrency, decimal amount)
        {
            try
            {
                PostExchangeRate entity = await _exchangeRateRepository.Get(originCurrency, destinationCurrency, amount);

                GetExchangeRate response = new GetExchangeRate()
                {
                    OriginCurrency = entity.OriginCurrency,
                    DestinationCurrency = entity.DestinationCurrency,
                    Amount = amount,
                    ExchangeRate = entity.ExchangeRate,
                    AmountChanged = amount * entity.ExchangeRate
                };

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task InsertAsync(PostExchangeRate entity)
        {
            try
            {
                await _exchangeRateRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}