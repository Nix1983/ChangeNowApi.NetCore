using ChangeNowApi_V2.Enums;

namespace ChangeNowApi_V2.Dto
{

    public class EstimatedExchangeAmountRequest : RequestBase
    {
        /// <summary>
        /// (Optional) Use rateId for fixed-rate flow.
        /// If this field is true, you could use returned field "rateId" in next method for creating transaction
        /// to freeze estimated amount that you got in this method.Current estimated amount would be valid until time in field "validUntil"
        /// </summary>
        public bool UseRateId { get; }

        public EstimatedExchangeAmountRequest(string fromCurrency, string toCurrency, decimal fromAmount, decimal toAmount = 0, FlowEnum flow = FlowEnum.Standard, DirectionEnum type = DirectionEnum.Direct, bool useRateId = false, string fromNetwork = "", string toNetwork = "")
            : base(fromCurrency, toCurrency, fromAmount, toAmount, fromNetwork, toNetwork, flow, type)
        {
            UseRateId = useRateId;
        }

        public EstimatedExchangeAmountRequest(string fromCurrency, string toCurrency, decimal fromAmount, FlowEnum flow = FlowEnum.Standard)
           : base(fromCurrency, toCurrency, fromAmount, 0, string.Empty, string.Empty, flow, DirectionEnum.Direct)
        {
            UseRateId = false;
        }

        public EstimatedExchangeAmountRequest(string fromCurrency, string toCurrency, decimal fromAmount, bool useRateId, FlowEnum flow = FlowEnum.FixedRate)
           : base(fromCurrency, toCurrency, fromAmount, 0, string.Empty, string.Empty, flow, DirectionEnum.Direct)
        {
            UseRateId = useRateId;
        }
    }
}
