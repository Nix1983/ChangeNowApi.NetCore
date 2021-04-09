using ChangeNowApi_V2.Dto.BaseClasses;
using Newtonsoft.Json;

namespace ChangeNowApi_V2.Dto
{
    public class CurrencyResponse : ResponseBase
    {
        /// <summary>
        /// Currency shortcut like btc
        /// </summary>
        [JsonProperty("ticker")]
        public string Ticker { get; set; }

        /// <summary>
        /// Full name like bitcoin
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Currency logo URL
        /// </summary>
        [JsonProperty("image")]
        public string ImageLink { get; set; }

        /// <summary>
        /// Indicates if a currency has an Extra ID
        /// </summary>
        [JsonProperty("hasExternalId")]
        public bool HasExternalId { get; set; }

        /// <summary>
        /// Indicates if a currency is a fiat currency (EUR, USD)
        /// </summary>
        [JsonProperty("isFiat")]
        public bool IsFiat { get; set; }

        /// <summary>
        /// Indicates if a currency is popular
        /// </summary>
        [JsonProperty("featured")]
        public bool Featured { get; set; }

        /// <summary>
        /// Indicates if a currency is stable
        /// </summary>
        [JsonProperty("isStable")]
        public bool IsStable { get; set; }

        /// <summary>
        /// Indicates if a currency is available on a fixed-rate flow
        /// </summary>
        [JsonProperty("supportsFixedRate")]
        public bool SupportedFixedRate { get; set; }

        /// <summary>
        /// Currency network
        /// </summary>
        [JsonProperty("network")]
        public string Network { get; set; }

        /// <summary>
        /// Contract for token or null for non-token
        /// </summary>
        [JsonProperty("tokenContract")]
        public string TokenContract { get; set; }

        /// <summary>
        /// Indicates if a currency is available to buy
        /// </summary>
        [JsonProperty("buy")]
        public bool Buy { get; set; }

        /// <summary>
        /// Indicates if a currency is available to sell
        /// </summary>
        [JsonProperty("sell")]
        public bool Sell { get; set; }

    }
}
