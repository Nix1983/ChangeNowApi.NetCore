using Newtonsoft.Json;

namespace ChangeNowApi_V2.Dto
{
    public class AddressValitationResponse
    {
        /// <summary>
        /// The validity of an address
        /// </summary>
        [JsonProperty("result")]
        public bool Result { get; set; }

        /// <summary>
        /// Explains why the address is invalid
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
