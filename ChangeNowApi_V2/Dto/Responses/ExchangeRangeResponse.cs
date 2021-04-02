using ChangeNowApi_V2.Dto.BaseClasses;
using Newtonsoft.Json;

namespace ChangeNowApi_V2.Dto
{
    public class ExchangeRangeResponse : ResponseBase
    {
   
        /// <summary>
        /// Minimal payment amount
        /// </summary>
        [JsonProperty("minAmount")]
        public decimal? MinAmount { get; set; }

        /// <summary>
        /// Maximum payment amount. Could be null.
        /// </summary>
        [JsonProperty("maxAmount")]
        public decimal? MaxAmount { get; set; }
    }
}
