using ChangeNowApi_V2.Enums;

namespace ChangeNowApi_V2.Dto
{
    public class CurrencyRequest : RequestBase
    {
        /// <summary>
        /// (Optional) Set true to return only active currencies
        /// </summary>
        public bool Active { get; }

        /// <summary>
        /// (Optional) If this field is true, only currencies available for buy are returned.
        /// </summary>
        public bool Buy { get; }

        /// <summary>
        /// (Optional) If this field is true, only currencies available for sell are returned.
        /// </summary>
        public bool Sell { get; }

        public CurrencyRequest(bool active, bool buy, bool sell, FlowEnum flow) : base(flow)
        {
            Active = active;
            Buy = buy;
            Sell = sell;
        }

        public CurrencyRequest(bool active, bool buy, bool sell) : base()
        {
            Active = active;
            Buy = buy;
            Sell = sell;
        }

        public CurrencyRequest(bool active, bool buy) : base()
        {
            Active = active;
            Buy = buy;
        }

        public CurrencyRequest(bool active) : base()
        {
            Active = active;
        }

        public CurrencyRequest() : base()
        {

        }


    }
}
