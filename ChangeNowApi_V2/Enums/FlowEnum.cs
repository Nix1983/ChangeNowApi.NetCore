namespace ChangeNowApi_V2.Enums
{
    /// <summary>
    /// Type of exchange flow
    /// standard or fixed-rate
    /// default is standard
    /// </summary>
    public enum FlowEnum
    {
        Standard,

        /// <summary>
        /// For this is a special API key necessary
        /// Contact the ChangeNow support for this
        /// </summary>
        FixedRate
    }

}
