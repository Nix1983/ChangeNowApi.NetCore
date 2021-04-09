using ChangeNowApi_V2.Enums;
using System;

namespace ChangeNowApi_V2.Dto
{
    public class AddressValidationRequest
    {
        /// <summary>
        /// (Required) The network of the address
        /// </summary>
        public string Currency { get; }

        /// <summary>
        /// (Required) Address for validation
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Info if validation is available for this currency
        /// </summary>
        public bool IsValidationAvailable { get; }

        public AddressValidationRequest(string currency, string address)
        {
            Currency = currency.ToLower();
            Address = address;
            IsValidationAvailable = Enum.IsDefined(typeof(CurrencyAddressValidationEnum), Currency);

        }

        public AddressValidationRequest(CurrencyAddressValidationEnum currency, string address)
        {
            Currency = currency.ToString();
            Address = address;
            IsValidationAvailable = true;
        }
    }
}
