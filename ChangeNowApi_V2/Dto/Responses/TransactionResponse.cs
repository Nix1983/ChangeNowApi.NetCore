using ChangeNowApi_V2.Dto.BaseClasses;
using Newtonsoft.Json;

namespace ChangeNowApi_V2.Dto
{
    public class TransactionResponse : ResponseBase
    {
        /// <summary>
        /// You can use it to get transaction status at the Transaction status API endpoint
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Amount of currency you want to exchange
        /// (Required if Type is direct) Must be greater then 0.
        /// </summary>
        [JsonProperty("fromAmount")]
        public string FromAmount { get; set; }

        /// <summary>
        /// Amount of currency you want to receive
        /// (Required if Type is reverse) Must be greater then 0.
        /// </summary>
        [JsonProperty("toAmount")]
        public string ToAmount { get; set; }

        /// <summary>
        /// Direction of exchange flow. Use "direct" value to set amount for currencyFrom and get amount of currencyTo. 
        /// Use "reverse" value to set amount for currencyTo and get amount of currencyFrom.
        /// [default = direct]
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// We generate it when creating a transaction
        /// </summary>
        [JsonProperty("payinAddress")]
        public string PayinAddress { get; set; }

        /// <summary>
        /// The wallet address that will recieve the exchanged funds
        /// </summary>
        [JsonProperty("payoutAddress")]
        public string PayoutAddress { get; set; }

        /// <summary>
        /// Whould generate it when creating a transaction
        /// </summary>
        [JsonProperty("payinExtraId")]
        public string PayinExtraId { get; set; }

        /// <summary>
        /// Extra ID that you send when creating a transaction
        /// </summary>
        [JsonProperty("payoutExtraId")]
        public string PayoutExtraId { get; set; }

        /// <summary>
        /// (Optional) Refund address 
        /// </summary>
        [JsonProperty("refundAddress")]
        public string RefundAddress { get; set; }

        /// <summary>
        /// (Optional) Refund Extra ID 
        /// </summary>
        [JsonProperty("refundExtraId")]
        public string RefundExtraId { get; set; }

        /// <summary>
        /// Field name currency Extra ID (e.g. Memo, Extra ID)
        /// </summary>
        [JsonProperty("payoutExtraIdName")]
        public string PayoutExtraIdName { get; set; }
    }
}
