using BCP.ExchangeRate.Domain.ExchangeRate;
using BCP.ExchangeRate.Repository.ExchangeRate;
using BCP.ExchangeRate.Repository.Redis.Core;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace BCP.ExchangeRate.Repository.Redis.ExchangeRate
{
    public class ExchangeRateRepository : IExchangeRateRepository
    {
        public ExchangeRateRepository()
        {

        }

        public async Task<PostExchangeRate> Get(string originCurrency, string destinationCurrency, decimal amount)
        {
            try
            {
                PostExchangeRate entity = new PostExchangeRate();

                var redisDB = RedisDB.Connection.GetDatabase();
                var exchangeRate = await redisDB.StringGetAsync($"{originCurrency.ToUpper()}-{destinationCurrency.ToUpper()}");
                if (!exchangeRate.HasValue)
                    throw new EntryPointNotFoundException($"No existe un tipo de cambio configurado para la moneda origen {originCurrency} y moneda destino {destinationCurrency}");
                
                entity = JsonConvert.DeserializeObject<PostExchangeRate>(exchangeRate);

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Insert(PostExchangeRate entity)
        {
            try
            {
                var redisDB = RedisDB.Connection.GetDatabase();
                await redisDB.StringSetAsync($"{entity.OriginCurrency.ToUpper()}-{entity.DestinationCurrency.ToUpper()}", JsonConvert.SerializeObject(entity));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}