namespace ChangeNowApi_V2.Dto
{
    public class AddressValidationRequest
    {
        /// <summary>
        /// (Required) The network of the address
        /// </summary>
        public string Curreny { get; set; }

        /// <summary>
        /// (Required) Address for validation
        /// </summary>
        public string Adresse { get; set; }

    }
}
