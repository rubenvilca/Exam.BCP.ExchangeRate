namespace BCP.ExchangeRate.Domain.ExchangeRate
{
    public class PostExchangeRate
    {
        #region Properties

        public string OriginCurrency { get; set; }
        public string DestinationCurrency { get; set; }
        public decimal ExchangeRate { get; set; }

        #endregion
    }
}