using ChangeNowApi_V2.Dto.BaseClasses;
using Newtonsoft.Json;

namespace ChangeNowApi_V2.Dto
{
    public class EstimatedExchangeAmountResponse : ResponseBase
    {
        /// <summary>
        /// Direction of exchange flow. Use "direct" value to set amount for currencyFrom and get amount of currencyTo. 
        /// Use "reverse" value to set amount for currencyTo and get amount of currencyFrom. Default is direct
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; } = Enums.Direction.Direct;

        /// <summary>
        /// RateId is needed for fixed-rate flow. If you set param "useRateId" to true,
        /// you could use returned field "rateId" in next method for creating transaction to freeze estimated amount that you got in this method. 
        /// Current estimated amount would be valid until time in field "validUntil"
        /// </summary>
        [JsonProperty("rateId")]
        public string RateId { get; set; }

        /// <summary>
        /// Date and time before estimated amount would be freezed in case of using rateId. 
        /// If you set param "useRateId" to true, you could use returned field "rateId" in next method for creating transaction to freeze estimated amount that you got in this method. 
        /// Estimated amount would be valid until this date and time
        /// </summary>
        [JsonProperty("validUntil")]
        public string ValidUntil { get; set; }

        /// <summary>
        /// Dash-separated min and max estimated time in minutes
        /// </summary>
        [JsonProperty("transactionSpeedForecast")]
        public string TransactionSpeedForecast { get; set; }

        /// <summary>
        /// Some warnings like warnings that transactions on this network take longer or that the currency has moved to another network
        /// </summary>
        [JsonProperty("WarningMessage")]
        public string warningMessage { get; set; }

        /// <summary>
        /// Exchange amount of fromCurrency (in case when type=reverse it is an estimated value)
        /// </summary>
        [JsonProperty("fromAmount")]
        public decimal fromAmount { get; set; }

        /// <summary>
        /// Exchange amount of toCurrency (in case when type=direct it is an estimated value)
        /// </summary>
        [JsonProperty("toAmount")]
        public string ToAmount { get; set; }
    }
}
