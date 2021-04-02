using Newtonsoft.Json;

namespace ChangeNowApi_V2.Dto
{
    public class FioAddressesResponse
    {
        /// <summary>
        /// Indicates if a request was processed successfully
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; set; }

        /// <summary>
        /// Array of addresses for requested fio-address
        /// </summary>
        [JsonProperty("addresses")]
        public string [] Addresses { get; set; }

        /// <summary>
        /// Currency ticker in naming space of his protocol
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Currency chain in naming space of his protocol
        /// </summary>
        [JsonProperty("chain")]
        public string Chain { get; set; }

        /// <summary>
        /// Real address for requested fio-address
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// Fio-protocol of current address
        /// </summary>
        [JsonProperty("protocol")]
        public string Protocol { get; set; }
    }
}
