namespace ChangeNowApi_V2.Dto
{
    public class FioAddressesRequest
    {
        /// <summary>
        /// (Required) FIO address
        /// </summary>
        public string Name { get; }

        public FioAddressesRequest(string name)
        {
            Name = name;
        }
    }
}
