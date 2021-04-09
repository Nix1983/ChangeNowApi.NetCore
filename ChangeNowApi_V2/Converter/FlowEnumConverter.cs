using ChangeNowApi_V2.Enums;

namespace ChangeNowApi_V2.Converter
{
    public static class FlowEnumConverter
    {
        public static string ToString(FlowEnum flow)
        {
            if (flow == FlowEnum.FixedRate)
            {
                return "fixed-rate";
            }
            else
            {
                return "standard";
            }
        }
    }
}
