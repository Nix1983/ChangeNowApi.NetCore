using ChangeNowApi_V2.Enums;

namespace ChangeNowApi_V2.Converter
{
    public static class DirectionEnumConverter
    {
        public static string ToString(DirectionEnum dircetion)
        {
            return dircetion.ToString().ToLower();
        }
    }
}
