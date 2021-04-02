namespace ChangeNowApi_V2.Dto
{
    public class EstimatedExchangeAmountRequest : RequestBase
    {
        /// <summary>
        /// (Required if type is direct) Must be greater then 0.
        /// </summary>
        public string FromAmount { get; set; }

        /// <summary>
        /// (Required if type is reverse) Must be greater then 0.
        /// </summary>
        public string ToAmount { get; set; }

        /// <summary>
        /// (Optional) Direction of exchange flow.Enum: ["direct", "reverse"]. Default value is direct
        /// </summary>
        public string Type { get; set; } = Enums.Direction.Direct;

        /// <summary>
        /// (Optional) Use rateId for fixed-rate flow.
        /// If this field is true, you could use returned field "rateId" in next method for creating transaction
        /// to freeze estimated amount that you got in this method.Current estimated amount would be valid until time in field "validUntil"
        /// </summary>
        public string UserRateId { get; set; }
    }
}
