namespace ChangeNowApi_V2.Dto
{
    public abstract class RequestBase
    {
        /// <summary>
        /// Ticker of the currency you want to exchange
        /// </summary>
        public string FromCurrency { get; set; }

        /// <summary>
        /// Network of the currency you want to exchange
        /// </summary>
        public string FromNetwork { get; set; }

        /// <summary>
        /// Ticker of the currency you want to receive
        /// </summary>
        public string ToCurrency { get; set; }

        /// <summary>
        /// Network of the currency you want to receive
        /// </summary>
        public string ToNetwork { get; set; }

        /// <summary>
        /// Type of exchange flow. Enum: ["standard", "fixed-rate"]
        /// </summary>
        public string Flow { get; set; } = Enums.Flow.Standard;
    }
}
