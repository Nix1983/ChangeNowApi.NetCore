﻿namespace ChangeNowApi_V2.Enums
{
    /// <summary>
    /// Direction of exchange flow. Use "direct" value to set amount for currencyFrom and get amount of currencyTo. 
    /// Use "reverse" value to set amount for currencyTo and get amount of currencyFrom.
    /// </summary>
    public static class Direction
    {
        public const string Direct = "direct";

        public const string Reverse = "reverse";
    }
}
