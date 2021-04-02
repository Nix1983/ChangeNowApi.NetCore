namespace ChangeNowApi_V2.Dto
{
    public class CurrencyRequest : RequestBase
    {
        /// <summary>
        /// (Optional) Set true to return only active currencies
        /// </summary>
        public string Active { get; set; }

        /// <summary>
        /// (Optional) If this field is true, only currencies available for buy are returned.
        /// </summary>
        public string Buy { get; set; }

        /// <summary>
        /// (Optional) If this field is true, only currencies available for sell are returned.
        /// </summary>
        public string Sell { get; set; }
    }
}
