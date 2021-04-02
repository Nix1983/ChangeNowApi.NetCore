using ChangeNowApi_V2.Dto.BaseClasses;
using Newtonsoft.Json;

namespace ChangeNowApi_V2.Dto
{
    public class TransactionStatusResponse : ResponseBase
    {
        /// <summary>
        /// Transaction ID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Transaction status:
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
       
        /// <summary>
        /// Indicates if an exchange can be pushed or refunded using Public push & refund endpoints.
        /// </summary>
        [JsonProperty("actionsAvailable")]
        public bool ActionsAvailable { get; set; }

        /// <summary>
        /// The amount you want to send
        /// </summary>
        [JsonProperty("expectedAmountFrom")]
        public decimal? ExpectedAmountFrom { get; set; }

        /// <summary>
        /// Estimated value that you will get based on the field expectedAmountFrom.
        /// </summary>
        [JsonProperty("expectedAmountTo")]
        public decimal? ExpectedAmountTo { get; set; }

        /// <summary>
        /// Exchange amount of fromCurrency
        /// </summary>
        [JsonProperty("amountFrom")]
        public decimal? AmountFrom { get; set; }

        /// <summary>
        /// Exchange amount of toCurrency
        /// </summary>
        [JsonProperty("amountTo")]
        public decimal? AmountTo { get; set; }

        /// <summary>
        /// Generated when creating a transaction
        /// </summary>
        [JsonProperty("payinAddress")]
        public string PayinAddress { get; set; }

        /// <summary>
        /// The wallet address that will recieve the exchanged funds.
        /// Should the same how in property address in TransactionRequest and must be valid
        /// </summary>
        [JsonProperty("payoutAddress")]
        public string PayoutAddress { get; set; }

        /// <summary>
        /// Generated when creating a transaction
        /// </summary>
        [JsonProperty("payinExtraId")]
        public string PayinExtraId { get; set; }

        /// <summary>
        /// Extra ID that you send when creating a transaction
        /// </summary>
        [JsonProperty("payoutExtraId")]
        public string PayoutExtraId { get; set; }

        /// <summary>
        /// Refund address (if you specified it)
        /// </summary>
        [JsonProperty("refundAddress")]
        public string RefundAddress { get; set; }

        /// <summary>
        /// ExtraId for refund (if you specified it)
        /// </summary>
        [JsonProperty("refundExtraId")]
        public string RefundExtraId { get; set; }

        /// <summary>
        /// Transaction creation date and time
        /// </summary>
        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Date and time of the last transaction update (e.g. status update)
        /// </summary>
        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }

        /// <summary>
        /// Deposit receiving date and time
        /// </summary>
        [JsonProperty("depositReceivedAt")]
        public string DepositReceivedAt { get; set; }

        /// <summary>
        /// Transaction hash in the blockchain of the currency 
        /// which you specified in the fromCurrency field that you send when creating the transaction
        /// </summary>
        [JsonProperty("payinHash")]
        public string PayinHash { get; set; }

        /// <summary>
        /// Transaction hash in the blockchain of the currency 
        /// which you specified in the toCurrency field. We generate it when creating a transaction
        /// </summary>
        [JsonProperty("payoutHash")]
        public string PayoutHash { get; set; }

        /// <summary>
        /// Ticker of the currency you want to exchange in an old format as it is specified in a response from Currency info API-v1 endpoint
        /// </summary>
        [JsonProperty("fromLegacyTicker")]
        public string FromLegacyTicker { get; set; }

        /// <summary>
        /// Ticker of the currency you want to receive in an old format as it is specified in a response from Currency info API-v1 endpoint
        /// </summary>
        [JsonProperty("toLegacyTicker")]
        public string ToLegacyTicker { get; set; }
    }
}
