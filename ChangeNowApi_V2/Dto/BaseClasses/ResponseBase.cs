using ChangeNowApi_V2.Converter;
using ChangeNowApi_V2.Enums;
using Newtonsoft.Json;

namespace ChangeNowApi_V2.Dto.BaseClasses
{
    public abstract class ResponseBase
    {
        /// <summary>
        /// Ticker of the currency you want to exchange
        /// </summary>
        [JsonProperty("fromCurrency")]
        public string FromCurrency { get; set; }

        /// <summary>
        /// Network of the currency you want to exchange
        /// </summary>
        [JsonProperty("fromNetwork")]
        public string FromNetwork { get; set; }

        /// <summary>
        /// Ticker of the currency you want to receive
        /// </summary>
        [JsonProperty("toCurrency")]
        public string ToCurrency { get; set; }

        /// <summary>
        /// Network of the currency you want to receive
        /// </summary>
        [JsonProperty("toNetwork")]
        public string ToNetwork { get; set; }

        /// <summary>
        /// Type of exchange flow.
        /// </summary>
        [JsonProperty("flow")]
        [JsonConverter(typeof(FlowEnumJsonConverter))]
        public FlowEnum Flow { get; set; }

        /// <summary>
        /// Response status code
        /// </summary>
        [JsonIgnore]
        public string StatusCode { get; set; }

        /// <summary>
        /// Response error message
        /// </summary>
        [JsonIgnore]
        public string ErroeMessage { get; set; }
    }
}
