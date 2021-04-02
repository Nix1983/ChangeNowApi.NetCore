using ChangeNowApi_V2.Dto;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChangeNowApi_V2
{
    public class ChangeNowClient
    {
        #region //---- member ----

        private static string ApiKey { get; set; }

        #endregion

        #region //---- Construction ----

        public ChangeNowClient(string apiKey)
        {
            ApiKey = apiKey;

        }

        #endregion

        #region //---- public functions----

        public async Task<List<CurrencyResponse>> GetListOfAvailableCurrenciesAsync(CurrencyRequest request)
        {
            IRestResponse response = await DoRequestAsync(GetAvailableCurrencyQueryString(request));
            return JsonConvert.DeserializeObject<List<CurrencyResponse>>(response.Content);
        }

        public List<CurrencyResponse> GetListOfAvailableCurrencies(CurrencyRequest request)
        {
            return JsonConvert.DeserializeObject<List<CurrencyResponse>>(DoRequest(GetAvailableCurrencyQueryString(request)).Content);
        }

        public MinimalExchangeResponse GetMinimalExchangeAmount(MinimalExchangeRequest request)
        {
            return JsonConvert.DeserializeObject<MinimalExchangeResponse>(DoRequest(GetMinimalExchangeAmountQueryString(request)).Content);
        }

        public async Task<MinimalExchangeResponse> GetMinimalExchangeAmountAsync(MinimalExchangeRequest info)
        {
            var response = await DoRequestAsync(GetMinimalExchangeAmountQueryString(info));
            return JsonConvert.DeserializeObject<MinimalExchangeResponse>(response.Content);
        }

        public ExchangeRangeResponse GetExchangeRange(ExchangeRangeRequest request)
        {
            return JsonConvert.DeserializeObject<ExchangeRangeResponse>(DoRequest(GetExchangeRangeQueryString(request)).Content);
        }

        public async Task<ExchangeRangeResponse> GetExchangeRangeAsync(ExchangeRangeRequest request)
        {
            var response = await DoRequestAsync(GetExchangeRangeQueryString(request));
            return JsonConvert.DeserializeObject<ExchangeRangeResponse>(response.Content);
        }

        public async Task<EstimatedExchangeAmountResponse> GetEstimatedExchangeAmountAsync(EstimatedExchangeAmountRequest info)
        {
            var response = await DoRequestAsync(GetGetEstimatedExchangeAmountQueryString(info));
            return JsonConvert.DeserializeObject<EstimatedExchangeAmountResponse>(response.Content);
        }

        public EstimatedExchangeAmountResponse GetEstimatedExchangeAmount(EstimatedExchangeAmountRequest info)
        {
            var response = DoRequest(GetGetEstimatedExchangeAmountQueryString(info));
            return JsonConvert.DeserializeObject<EstimatedExchangeAmountResponse>(response.Content);
        }

        public async Task<TransactionResponse> CreateExchangeTransactionAsync(TransactionRequest requestObj)
        {
            var client = new RestClient(Enums.ApiEndPoints.Exchange);
            client.Timeout = -1;
            var request = GetCreateRequest(requestObj);
            IRestResponse response = await client.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<TransactionResponse>(response.Content);
        }

        public TransactionResponse CreateExchangeTransaction(TransactionRequest requestObj)
        {
            var client = new RestClient(Enums.ApiEndPoints.Exchange);
            client.Timeout = -1;
            var request = GetCreateRequest(requestObj);
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<TransactionResponse>(response.Content);
        }

        public TransactionStatusResponse GetTransactionStatus(TransactionStatusRequest request)
        {
            if (request == null)
            {
                request = new TransactionStatusRequest();
            }

            IRestResponse response = DoRequest(GetTransactionStatusQueryString(request.Id));
            return JsonConvert.DeserializeObject<TransactionStatusResponse>(response.Content);
        }

        public async Task<TransactionStatusResponse> GetTransactionStatusAsync(TransactionStatusRequest request)
        {
            if(request == null)
            {
                request = new TransactionStatusRequest(); 
            }

            IRestResponse response = await DoRequestAsync(GetTransactionStatusQueryString(request.Id));
            return JsonConvert.DeserializeObject<TransactionStatusResponse>(response.Content);
        }

        public TransactionStatusResponse GetTransactionStatus(string request)
        {
            return JsonConvert.DeserializeObject<TransactionStatusResponse>(DoRequest(GetTransactionStatusQueryString(request)).Content);
        }

        public async Task<TransactionStatusResponse> GetTransactionStatusAsync(string request)
        {
            IRestResponse response = await DoRequestAsync(GetTransactionStatusQueryString(request));
            return JsonConvert.DeserializeObject<TransactionStatusResponse>(response.Content);
        }

        public AddressValitationResponse ValidateAddress(AddressValidationRequest request)
        {
            return JsonConvert.DeserializeObject<AddressValitationResponse>(DoRequest(GetAddressValidationQueryString(request)).Content);
        }

        public async Task<AddressValitationResponse> ValidateAddressAsync(AddressValidationRequest request)
        {
            IRestResponse response = await DoRequestAsync(GetAddressValidationQueryString(request));
            return JsonConvert.DeserializeObject<AddressValitationResponse>(response.Content);
        }

        public FioAddressesResponse GetFioAddresses(FioAddressesRequest request)
        {
            return JsonConvert.DeserializeObject<FioAddressesResponse>(DoRequest(GetFioAddressesQueryString(request)).Content);
        }

        public async Task<FioAddressesResponse> GetFioAddressesAsync(FioAddressesRequest request)
        {
            IRestResponse response = await DoRequestAsync(GetFioAddressesQueryString(request));
            return JsonConvert.DeserializeObject<FioAddressesResponse>(response.Content);
        }

        public MarketEstimatedResponse GetMarketEstimatedInfos(MarketEstimatedRequest request)
        {
            return JsonConvert.DeserializeObject<MarketEstimatedResponse>(DoRequest(GetMarketEstimatedQueryString(request)).Content);
        }

        public async Task<MarketEstimatedResponse> GetMarketEstimatedInfosAsync(MarketEstimatedRequest request)
        {
            IRestResponse response = await DoRequestAsync(GetMarketEstimatedQueryString(request));
            return JsonConvert.DeserializeObject<MarketEstimatedResponse>(response.Content);
        }

        #endregion

        #region //---- private functions----

        private string GetGetEstimatedExchangeAmountQueryString(EstimatedExchangeAmountRequest request)
        {
            if (request != null)
            {
                return $"{Enums.ApiEndPoints.Exchange}estimated-amount?fromCurrency={request.FromCurrency}&toCurrency={request.ToCurrency}&fromAmount={request.FromAmount}&toAmount={request.ToAmount}&fromNetwork={request.FromNetwork}&toNetwork={request.ToNetwork}&flow={request.Flow}&type={request.Type}&useRateId={request.UseRateId}";
            }
            else
            {
                return $"{Enums.ApiEndPoints.Exchange}estimated-amount?fromCurrency=&toCurrency=&fromAmount=&toAmount=&fromNetwork=&toNetwork=&flow=&type=&useRateId=";
            }

        }

        private async Task<IRestResponse> DoRequestAsync(string query)
        {
            var client = new RestClient(query);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader(Enums.ApiEndPoints.XChangeNowHeaderKey, ApiKey);
            return await client.ExecuteAsync(request);
        }

        private IRestResponse DoRequest(string query)
        {
            var client = new RestClient(query);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader(Enums.ApiEndPoints.XChangeNowHeaderKey, ApiKey);
            return client.Execute(request);
        }

        private RestRequest GetCreateRequest(TransactionRequest requestObj)
        {
            var request = new RestRequest(Method.POST);
            request.AddHeader(Enums.ApiEndPoints.ContentType, Enums.ApiEndPoints.ApplicationJson);
            request.AddHeader(Enums.ApiEndPoints.XChangeNowHeaderKey, ApiKey);

            if (requestObj != null)
            {
                request.AddParameter(Enums.ApiEndPoints.ApplicationJson,
                    "{" +
                    $"\n    \"fromCurrency\": \"{requestObj.FromCurrency}\"," +
                    $"\n    \"toCurrency\": \"{requestObj.ToCurrency}\"," +
                    $"\n    \"fromNetwork\": \"{requestObj.FromNetwork}\"," +
                    $"\n    \"toNetwork\": \"{requestObj.ToNetwork}\"," +
                    $"\n    \"fromAmount\": \"{requestObj.FromAmount}\"," +
                    $"\n    \"toAmount\": \"{requestObj.ToAmount}\"," +
                    $"\n    \"address\": \"{requestObj.Address}\"," +
                    $"\n    \"extraId\": \"{requestObj.ExtraId}\"," +
                    $"\n    \"refundAddress\": \"{requestObj.RefundAddress}\"," +
                    $"\n    \"refundExtraId\": \"{requestObj.RefundExtraId}\"," +
                    $"\n    \"userId\": \"{requestObj.UserId}\"," +
                    $"\n    \"payload\": \"{requestObj.Payload}\"," +
                    $"\n    \"contactEmail\": \"{requestObj.ConactEmail}\"," +
                    $"\n    \"source\": \"\"," +
                    $"\n    \"flow\": \"{requestObj.Flow}\"," +
                    $"\n    \"type\": \"{requestObj.Type}\"," +
                    $"\n    \"rateId\": \"{requestObj.RateID}\"" +
                    $"\n" +
                    "}", ParameterType.RequestBody);
            }
            else
            {
                request.AddParameter(Enums.ApiEndPoints.ApplicationJson,
                    "{" +
                    $"\n    \"fromCurrency\": \"\"," +
                    $"\n    \"toCurrency\": \"\"," +
                    $"\n    \"fromNetwork\": \"\"," +
                    $"\n    \"toNetwork\": \"\"," +
                    $"\n    \"fromAmount\": \"\"," +
                    $"\n    \"toAmount\": \"\"," +
                    $"\n    \"address\": \"\"," +
                    $"\n    \"extraId\": \"\"," +
                    $"\n    \"refundAddress\": \"\"," +
                    $"\n    \"refundExtraId\": \"\"," +
                    $"\n    \"userId\": \"\"," +
                    $"\n    \"payload\": \"\"," +
                    $"\n    \"contactEmail\": \"\"," +
                    $"\n    \"source\": \"\"," +
                    $"\n    \"flow\": \"\"," +
                    $"\n    \"type\": \"\"," +
                    $"\n    \"rateId\": \"\"" +
                    $"\n" +
                    "}", ParameterType.RequestBody);
            }
            return request;
        }

        private string GetTransactionStatusQueryString(string request)
        {
            if (request != null)
            {
                return $"{Enums.ApiEndPoints.Exchange}by-id?id={request}";
            }
            else
            {
                return $"{Enums.ApiEndPoints.Exchange}by-id?id=";
            }

        }

        private string GetAvailableCurrencyQueryString(CurrencyRequest request)
        {
            if (request != null)
            {
                return $"{Enums.ApiEndPoints.Exchange}currencies?active={request.Active}&flow={request.Flow}&buy={request.Buy}&sell={ request.Sell}";
            }
            else
            {
                return $"{Enums.ApiEndPoints.Exchange}currencies?active=&flow=&buy=&sell=";
            }

        }

        private string GetMinimalExchangeAmountQueryString(MinimalExchangeRequest request)
        {
            if (request != null)
            {
                return $"{Enums.ApiEndPoints.Exchange}min-amount?fromCurrency={request.FromCurrency}&toCurrency={request.ToCurrency}&fromNetwork={request.FromNetwork}&toNetwork={request.ToNetwork}&flow={request.Flow}";
            }
            else
            {
                return $"{Enums.ApiEndPoints.Exchange}min-amount?fromCurrency=&toCurrency=&fromNetwork=&toNetwork=&flow=";
            }
        }

        private string GetExchangeRangeQueryString(ExchangeRangeRequest request)
        {
            if (request != null)
            {
                return $"{Enums.ApiEndPoints.Exchange}range?fromCurrency={request.FromCurrency}&toCurrency={request.ToCurrency}&fromNetwork={request.FromNetwork}&toNetwork={request.ToNetwork}&flow={request.Flow}";
            }
            else
            {
                return $"{Enums.ApiEndPoints.Exchange}range?fromCurrency=&toCurrency=&fromNetwork=&toNetwork=&flow=";
            }
        }

        private string GetAddressValidationQueryString(AddressValidationRequest request)
        {
            if (request != null)
            {
                return $"{Enums.ApiEndPoints.Validation}address?currency={request.Curreny}&address={request.Adresse}";
            }
            else
            {
                return $"{Enums.ApiEndPoints.Validation}address?currency=&address=";
            }
        }

        private string GetFioAddressesQueryString(FioAddressesRequest request)
        {
            if (request != null)
            {
                return $"{Enums.ApiEndPoints.Root}addresses-by-name?name={request.Name}";
            }
            else
            {
                return $"{Enums.ApiEndPoints.Root}addresses-by-name?name=";
            }
        }

        private string GetMarketEstimatedQueryString(MarketEstimatedRequest request)
        {
            if (request != null)
            {
                return $"{Enums.ApiEndPoints.Markets}estimate?fromCurrency={request.FromCurrency}&toCurrency={request.ToCurrency}&fromAmount={request.FromAmount}&toAmount&type={request.Type}";

            }
            else
            {

                return $"{Enums.ApiEndPoints.Markets}estimate?fromCurrency=&toCurrency=&fromAmount=&toAmount&type=";
            }
        }

        #endregion
    }
}
