using ChangeNowApi_V2.Enums;

namespace ChangeNowApi_V2.Dto
{
    public class ExchangeRangeRequest : RequestBase
    {
        public ExchangeRangeRequest(string fromCurrency, string toCurrency, FlowEnum flow = FlowEnum.Standard, string fromNetwork = "", string toNetwork = "")
            : base(fromCurrency, toCurrency, fromNetwork, toNetwork, flow)
        {

        }
    }
}
