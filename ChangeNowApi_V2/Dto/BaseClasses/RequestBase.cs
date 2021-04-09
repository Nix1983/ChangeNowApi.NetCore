using ChangeNowApi_V2.Consts;
using ChangeNowApi_V2.Enums;

namespace ChangeNowApi_V2.Dto
{
    public abstract class RequestBase
    {
        /// <summary>
        /// Ticker of the currency you want to exchange
        /// </summary>
        public string FromCurrency { get; } = Messages.ParameterNotUseForThisRequest;

        /// <summary>
        /// Network of the currency you want to exchange
        /// </summary>
        public string FromNetwork { get; } = Messages.ParameterNotUseForThisRequest;

        /// <summary>
        /// Ticker of the currency you want to receive
        /// </summary>
        public string ToCurrency { get; } = Messages.ParameterNotUseForThisRequest;

        /// <summary>
        /// Network of the currency you want to receive
        /// </summary>
        public string ToNetwork { get; } = Messages.ParameterNotUseForThisRequest;

        /// <summary>
        /// (Required if type is direct) Must be greater then 0.
        /// </summary>
        public decimal FromAmount { get; } = 0;

        /// <summary>
        /// (Required if type is reverse) Must be greater then 0.
        /// </summary>
        public decimal ToAmount { get; } = 0;

        /// <summary>
        /// Type of exchange flow. Enum: ["standard", "fixed-rate"]
        /// </summary>
        public FlowEnum Flow { get; } = FlowEnum.Standard;

        /// <summary>
        /// Direction of exchange flow. Use "direct" value to set amount for currencyFrom and get amount of currencyTo. 
        /// Use "reverse" value to set amount for currencyTo and get amount of currencyFrom.
        /// [default = direct]
        /// </summary>
        public DirectionEnum Type { get; } = DirectionEnum.Direct;

        protected RequestBase()
        {

        }

        protected RequestBase(FlowEnum flow)
        {
            Flow = flow;
        }

        protected RequestBase(string fromCurrency, string toCurrency, string fromNetwork, string toNetwork, FlowEnum flow)
        {
            FromCurrency = fromCurrency;
            ToCurrency = toCurrency;
            FromNetwork = fromNetwork;
            ToNetwork = toNetwork;
            Flow = flow;
        }

        protected RequestBase(string fromCurrency, string toCurrency, decimal fromAmount, decimal toAmount, string fromNetwork, string toNetwork)
        {
            FromCurrency = fromCurrency;
            ToCurrency = toCurrency;
            FromAmount = fromAmount;
            ToAmount = toAmount;
            FromNetwork = fromNetwork;
            ToNetwork = toNetwork;
        }

        protected RequestBase(string fromCurrency, string toCurrency, decimal fromAmount, decimal toAmount, string fromNetwork, string toNetwork, FlowEnum flow, DirectionEnum type)
        {
            FromCurrency = fromCurrency;
            ToCurrency = toCurrency;
            FromAmount = fromAmount;
            ToAmount = toAmount;
            FromNetwork = fromNetwork;
            ToNetwork = toNetwork;
            Flow = flow;
            Type = type;
        }



    }
}
