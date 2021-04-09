using ChangeNowApi_V2.Enums;
using System;

namespace ChangeNowApi_V2.Converter
{
    public static class TransactionStatusEnumConverter
    {
        public static TransactionStatusEnum StringToEnum(string value)
        {
            if (value == null) return TransactionStatusEnum.UnKnown;
            value = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());

            if (!Enum.IsDefined(typeof(TransactionStatusEnum), value))
            {
                return TransactionStatusEnum.UnKnown;
            }
            Enum.TryParse(value, true, out TransactionStatusEnum status);

            return status;
        }

        public static string EnumToString(TransactionStatusEnum status)
        {
            return status.ToString().ToLower();
        }
    }
}
