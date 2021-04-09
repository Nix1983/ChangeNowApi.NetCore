using ChangeNowApi_V2.Consts;
using ChangeNowApi_V2.Enums;

namespace ChangeNowApi_V2.Dto
{
    public class MarketEstimatedRequest : RequestBase
    {
        public MarketEstimatedRequest(string fromCurrency, string toCurrency, decimal fromAmount, decimal toAmount = 0, DirectionEnum type = DirectionEnum.Direct)
            : base(fromCurrency, toCurrency, fromAmount, toAmount, Messages.ParameterNotUseForThisRequest, Messages.ParameterNotUseForThisRequest, FlowEnum.Standard, type)
        {
        }

    }
}
