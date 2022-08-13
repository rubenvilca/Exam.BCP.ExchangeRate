namespace BCP.ExchangeRate.Domain.ExchangeRate
{
    public class GetExchangeRate
    {
        #region Properties

        public string OriginCurrency { get; set; }
        public string DestinationCurrency { get; set; }
        public decimal Amount { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal AmountChanged { get; set; }

        #endregion
    }
}