using Newtonsoft.Json;

namespace ChangeNowApi_V2.Dto
{
    public class TransactionRequest : RequestBase
    {
      
        /// <summary>
        /// (Required if Type is direct) Must be greater then 0.
        /// </summary>
        public string FromAmount { get; set; }

        /// <summary>
        /// (Required if Type is reverse) Must be greater then 0.
        /// </summary>
        public string ToAmount { get; set; }

        /// <summary>
        /// (Required) Address to receive a currency.
        /// It must be a valid address for the to currency property
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// (Optional) Extra ID for currencies that require it
        /// </summary>
        public string ExtraId { get; set; }

        /// <summary>
        /// (Optional) Refund address 
        /// </summary>
        public string RefundAddress { get; set; }

        /// <summary>
        /// (Optional) Refund Extra ID 
        /// </summary>
        public string RefundExtraId { get; set; }

        /// <summary>
        /// (Optional) Partner user ID Note: This field is active only for our special partners.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// (Optional) Object that can contain up to 5 arbitrary fields up to 64 characters long 
        /// Note: This field is active only for our special partners.
        /// </summary>
        public string Payload { get; set; }

        /// <summary>
        /// (Optional) Your contact email for notification in case something goes wrong with your exchange
        /// </summary>
        public string ConactEmail { get; set; }

        /// <summary>
        /// Direction of exchange flow. Use "direct" value to set amount for currencyFrom and get amount of currencyTo. 
        /// Use "reverse" value to set amount for currencyTo and get amount of currencyFrom.
        /// [default = direct]
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// (Optional) Use rateId for fixed-rate flow. 
        /// Set it to value that you got from previous method for estimated amount to freeze estimated amount.
        /// </summary>
        public string RateID { get; set; }

    }
}
