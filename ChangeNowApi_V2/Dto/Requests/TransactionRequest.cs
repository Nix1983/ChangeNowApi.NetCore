using ChangeNowApi_V2.Enums;

namespace ChangeNowApi_V2.Dto
{
    public class TransactionRequest : RequestBase
    {
        /// <summary>
        /// (Required) Address to receive a currency.
        /// It must be a valid address for the to currency property
        /// </summary>
        public string Address { get; } = string.Empty;

        /// <summary>
        /// (Optional) Extra ID for currencies that require it
        /// </summary>
        public string ExtraId { get; } = string.Empty;

        /// <summary>
        /// (Optional) Refund address 
        /// </summary>
        public string RefundAddress { get; } = string.Empty;

        /// <summary>
        /// (Optional) Refund Extra ID 
        /// </summary>
        public string RefundExtraId { get; } = string.Empty;

        /// <summary>
        /// (Optional) Partner user ID Note: This field is active only for our special partners.
        /// </summary>
        public string UserId { get; } = string.Empty;

        /// <summary>
        /// (Optional) Object that can contain up to 5 arbitrary fields up to 64 characters long 
        /// Note: This field is active only for our special partners.
        /// </summary>
        public string PayLoad { get; } = string.Empty;

        /// <summary>
        /// (Optional) Your contact email for notification in case something goes wrong with your exchange
        /// </summary>
        public string ConactEmail { get; } = string.Empty;

        /// <summary>
        /// (Optional) Use rateId for fixed-rate flow. 
        /// Set it to value that you got from previous method for estimated amount to freeze estimated amount.
        /// </summary>
        public string RateID { get; } = string.Empty;

        public TransactionRequest(string fromCurrency, string toCurrency, decimal fromAmount, string address, FlowEnum flow, DirectionEnum type,
            decimal toAmount, string extraID, string refundAddress, string refundExtraId, string userId, string payLoad,
            string contactEmail, string rateID, string fromNetwork, string toNetwork)
            : base(fromCurrency, toCurrency, fromAmount, toAmount, fromNetwork, toNetwork, flow, type)
        {
            Address = address;
            ExtraId = extraID;
            RefundAddress = refundAddress;
            RefundExtraId = refundExtraId;
            UserId = userId;
            PayLoad = payLoad;
            ConactEmail = contactEmail;
            RateID = rateID;

        }

        public TransactionRequest(string fromCurrency, string toCurrency, decimal fromAmount, string address, FlowEnum flow)
            : base(fromCurrency, toCurrency, fromAmount, 0, string.Empty, string.Empty, flow, DirectionEnum.Direct)
        {
            Address = address;

        }

        public TransactionRequest(string fromCurrency, string toCurrency, decimal fromAmount, string address) : base(fromCurrency, toCurrency, fromAmount, 0, string.Empty, string.Empty)
        {
            Address = address;
        }
    }
}
