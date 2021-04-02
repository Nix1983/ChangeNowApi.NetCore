namespace ChangeNowApi_V2.Dto
{
    public class MarketEstimatedRequest
    {
        /// <summary>
        /// (Required) "From" currency
        /// </summary>
        public string FromCurrency { get; set; }

        /// <summary>
        /// (Required) "To" currency
        /// </summary>
        public string ToCurrency { get; set; }

        /// <summary>
        /// (Optional) Set if this is a direct type of the estimated amount
        /// </summary>
        public string FromAmount { get; set; }

        /// <summary>
        /// (Optional) Set if this is a reverse type of the estimated amount
        /// </summary>
        public string ToAmount { get; set; }

        /// <summary>
        /// (Optional) Valid values: [direct, reverse] If the type is not set, ‘direct’ is used by default.
        /// </summary>
        public string Type { get; set; } = Enums.Direction.Direct;
    }
}
