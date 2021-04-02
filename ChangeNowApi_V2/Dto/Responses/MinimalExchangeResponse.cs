using ChangeNowApi_V2.Dto.BaseClasses;
using Newtonsoft.Json;

namespace ChangeNowApi_V2.Dto
{
    public class MinimalExchangeResponse : ResponseBase
    {
        
        /// <summary>
        /// Minimal payment amount
        /// </summary>
        [JsonProperty("minAmount")]
        public decimal? MinAmount { get; set; }
    }
}
