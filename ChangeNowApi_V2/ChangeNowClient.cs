using ChangeNowApi_V2.Dto;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Net;
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
            return CurrencyResponseErrorHandle(response);
        }

        public List<CurrencyResponse> GetListOfAvailableCurrencies(CurrencyRequest request)
        {
            return CurrencyResponseErrorHandle(DoRequest(GetAvailableCurrencyQueryString(request)));
        }

        public MinimalExchangeResponse GetMinimalExchangeAmount(MinimalExchangeRequest request)
        {
            return MinimalExchangeResponseErrorHandle(DoRequest(GetMinimalExchangeAmountQueryString(request)));
        }

        public async Task<MinimalExchangeResponse> GetMinimalExchangeAmountAsync(MinimalExchangeRequest request)
        {
            var response = await DoRequestAsync(GetMinimalExchangeAmountQueryString(request));
            return MinimalExchangeResponseErrorHandle(response);
        }

        public ExchangeRangeResponse GetExchangeRange(ExchangeRangeRequest request)
        {
            return ExchangeRangeResponseErrorHandle(DoRequest(GetExchangeRangeQueryString(request)));
        }

        public async Task<ExchangeRangeResponse> GetExchangeRangeAsync(ExchangeRangeRequest request)
        {
            var response = await DoRequestAsync(GetExchangeRangeQueryString(request));
            return ExchangeRangeResponseErrorHandle(response);
        }

        public async Task<EstimatedExchangeAmountResponse> GetEstimatedExchangeAmountAsync(EstimatedExchangeAmountRequest request)
        {
            var response = await DoRequestAsync(GetGetEstimatedExchangeAmountQueryString(request));
            return EstimatedExchangeAmountResponseErrorHandle(response);
        }

        public EstimatedExchangeAmountResponse GetEstimatedExchangeAmount(EstimatedExchangeAmountRequest request)
        {
            return EstimatedExchangeAmountResponseErrorHandle(DoRequest(GetGetEstimatedExchangeAmountQueryString(request)));
        }

        public async Task<TransactionResponse> CreateExchangeTransactionAsync(TransactionRequest request)
        {
            var client = new RestClient(Enums.ApiEndPoints.Exchange);
            client.Timeout = -1;
            IRestResponse response = await client.ExecuteAsync(GetCreateRequest(request));
            return CreateExchangeErrorHandle(response);
        }

        public TransactionResponse CreateExchangeTransaction(TransactionRequest request)
        {
            var client = new RestClient(Enums.ApiEndPoints.Exchange);
            client.Timeout = -1;
            return CreateExchangeErrorHandle(client.Execute(GetCreateRequest(request)));
       
        }

        public TransactionStatusResponse GetTransactionStatus(TransactionStatusRequest request)
        {
            if (request == null)
            {
                request = new TransactionStatusRequest();
            }

            return TransactionStatusResponseErrorHandle(DoRequest(GetTransactionStatusQueryString(request.Id)));
        }

        public async Task<TransactionStatusResponse> GetTransactionStatusAsync(TransactionStatusRequest request)
        {
            if(request == null)
            {
                request = new TransactionStatusRequest(); 
            }

            IRestResponse response = await DoRequestAsync(GetTransactionStatusQueryString(request.Id));
            return TransactionStatusResponseErrorHandle(response);
        }

        public TransactionStatusResponse GetTransactionStatus(string request)
        {
            return TransactionStatusResponseErrorHandle(DoRequest(GetTransactionStatusQueryString(request)));
        }

        public async Task<TransactionStatusResponse> GetTransactionStatusAsync(string request)
        {
            IRestResponse response = await DoRequestAsync(GetTransactionStatusQueryString(request));
            return TransactionStatusResponseErrorHandle(response);
        }

        public AddressValitationResponse ValidateAddress(AddressValidationRequest request)
        {
            return AddressValitationResponseErrorHandle(DoRequest(GetAddressValidationQueryString(request)));
        }

        public async Task<AddressValitationResponse> ValidateAddressAsync(AddressValidationRequest request)
        {
            IRestResponse response = await DoRequestAsync(GetAddressValidationQueryString(request));
            return AddressValitationResponseErrorHandle(response);
        }

        public FioAddressesResponse GetFioAddresses(FioAddressesRequest request)
        {
            return FioAddressesResponseErrorHandle(DoRequest(GetFioAddressesQueryString(request)));
        }

        public async Task<FioAddressesResponse> GetFioAddressesAsync(FioAddressesRequest request)
        {
            IRestResponse response = await DoRequestAsync(GetFioAddressesQueryString(request));
            return FioAddressesResponseErrorHandle(response);
        }

        public MarketEstimatedResponse GetMarketEstimatedInfos(MarketEstimatedRequest request)
        {
            return MarketEstimatedResponseErrorHandle(DoRequest(GetMarketEstimatedQueryString(request)));
        }

        public async Task<MarketEstimatedResponse> GetMarketEstimatedInfosAsync(MarketEstimatedRequest request)
        {
            IRestResponse response = await DoRequestAsync(GetMarketEstimatedQueryString(request));
            return MarketEstimatedResponseErrorHandle(response);
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
                return $"{Enums.ApiEndPoints.Validation}address?currency={request.Curreny}&address={request.Adress}";
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

        private TransactionResponse CreateExchangeErrorHandle(IRestResponse response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<TransactionResponse>(response.Content);
            }
            else
            {
                var result = new TransactionResponse();
                result.StatusCode = response.StatusCode.ToString();
                result.ErroeMessage = response.Content;
                return result;
            }
        }

        private List<CurrencyResponse> CurrencyResponseErrorHandle(IRestResponse response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<CurrencyResponse>>(response.Content);
            }
            else
            {
                var list = new List<CurrencyResponse>();
                var result = new CurrencyResponse();
                result.StatusCode = response.StatusCode.ToString();
                result.ErroeMessage = response.Content;
                list.Add(result);
                return list;
            }
        }

        private MinimalExchangeResponse MinimalExchangeResponseErrorHandle(IRestResponse response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<MinimalExchangeResponse>(response.Content);
            }
            else
            {
                var result = new MinimalExchangeResponse();
                result.StatusCode = response.StatusCode.ToString();
                result.ErroeMessage = response.Content;
                return result;
            }
        }

        private ExchangeRangeResponse ExchangeRangeResponseErrorHandle(IRestResponse response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<ExchangeRangeResponse>(response.Content);
            }
            else
            {
                var result = new ExchangeRangeResponse();
                result.StatusCode = response.StatusCode.ToString();
                result.ErroeMessage = response.Content;
                return result;
            }
        }

        private EstimatedExchangeAmountResponse EstimatedExchangeAmountResponseErrorHandle(IRestResponse response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<EstimatedExchangeAmountResponse>(response.Content);
            }
            else
            {
                var result = new EstimatedExchangeAmountResponse();
                result.StatusCode = response.StatusCode.ToString();
                result.ErroeMessage = response.Content;
                return result;
            }
        }

        private TransactionStatusResponse TransactionStatusResponseErrorHandle(IRestResponse response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<TransactionStatusResponse>(response.Content);
            }
            else
            {
                var result = new TransactionStatusResponse();
                result.StatusCode = response.StatusCode.ToString();
                result.ErroeMessage = response.Content;
                return result;
            }
        }

        private AddressValitationResponse AddressValitationResponseErrorHandle(IRestResponse response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<AddressValitationResponse>(response.Content);
            }
            else
            {
                var result = new AddressValitationResponse();
                result.StatusCode = response.StatusCode.ToString();
                result.ErroeMessage = response.Content;
                return result;
            }
        }

        private FioAddressesResponse FioAddressesResponseErrorHandle(IRestResponse response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<FioAddressesResponse>(response.Content);
            }
            else
            {
                var result = new FioAddressesResponse();
                result.StatusCode = response.StatusCode.ToString();
                result.ErroeMessage = response.Content;
                return result;
            }
        }

        private MarketEstimatedResponse MarketEstimatedResponseErrorHandle(IRestResponse response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<MarketEstimatedResponse>(response.Content);
            }
            else
            {
                var result = new MarketEstimatedResponse();
                result.StatusCode = response.StatusCode.ToString();
                result.ErroeMessage = response.Content;
                return result;
            }
        }

        #endregion
    }
}
