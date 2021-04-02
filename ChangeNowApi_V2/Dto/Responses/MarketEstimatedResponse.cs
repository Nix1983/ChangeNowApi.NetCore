using ChangeNowApi_V2.Dto.BaseClasses;
using Newtonsoft.Json;

namespace ChangeNowApi_V2.Dto
{
    public class MarketEstimatedResponse : ResponseBase
    {
        /// <summary>
        /// “From” currency
        /// </summary>
        [JsonProperty("fromCurrency")]
        public string FromCurrency { get; set; }

        /// <summary>
        /// “To” currency
        /// </summary>
        [JsonProperty("toCurrency")]
        public string ToCurrency { get; set; }

        /// <summary>
        /// The amount of “from” currency
        /// </summary>
        [JsonProperty("fromAmount")]
        public string FromAmount { get; set; }

        /// <summary>
        /// The amount of “to” currency
        /// </summary>
        [JsonProperty("toAmount")]
        public string ToAmount { get; set; }

        /// <summary>
        /// The type of the estimated amount — direct or reverse
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
