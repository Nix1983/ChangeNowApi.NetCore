using ChangeNowApi_V2;
using ChangeNowApi_V2.Converter;
using ChangeNowApi_V2.Dto;
using ChangeNowApi_V2.Enums;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTests
{
    public class Tests
    {
        private ChangeNowClient _client;

        /// <summary>
        /// Note! You have to use your own ApiKey. Without key some test will fail
        /// </summary>
        private const string _apiKey = "Your API KEY";

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _client = ChangeNowClient.GetClient(_apiKey);
        }

        /// <summary>
        /// Wait a second after each test so as not to send too many requests
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(1000);
        }

        [Test]
        [TestCase(true, true, true, FlowEnum.Standard)]
        [TestCase(true, false, false, FlowEnum.FixedRate)]
        [TestCase(false, false, true, FlowEnum.Standard)]
        [TestCase(false, false, false, FlowEnum.Standard)]
        [TestCase(true, false, false, FlowEnum.Standard)]
        [TestCase(false, true, false, FlowEnum.Standard)]
        public async Task GetListOfAvailableCurrenciesAsyncTest(bool sell, bool buy, bool active, FlowEnum flow)
        {

            var request = new CurrencyRequest(active, buy, sell, flow);

            var result = await _client.GetListOfAvailableCurrenciesAsync(request);

            Assert.NotNull(result);
            Assert.True(result.Count > 0);
        }

        [Test]
        [TestCase(true, true, true, FlowEnum.Standard)]
        [TestCase(true, true, true, FlowEnum.FixedRate)]
        [TestCase(false, false, true, FlowEnum.Standard)]
        [TestCase(false, false, false, FlowEnum.Standard)]
        [TestCase(true, false, false, FlowEnum.Standard)]
        [TestCase(false, true, false, FlowEnum.Standard)]
        public void GetListOfAvailableCurrenciesTest(bool sell, bool buy, bool active, FlowEnum flow)
        {

            var request = new CurrencyRequest(active, buy, sell, flow);

            var result = _client.GetListOfAvailableCurrencies(request);

            Assert.NotNull(result);
            Assert.True(result.Count > 0);

        }

        [Test]
        [TestCase("btc", "doge", FlowEnum.Standard, null, null)]
        public async Task GetMinimalExchangeAmountAsyncTest(string fromCurrency, string toCurrency, FlowEnum flow, string fromNetwork, string toNetwork)
        {

            var request = new MinimalExchangeRequest(fromCurrency, toCurrency, flow, fromNetwork, toNetwork);

            var result = await _client.GetMinimalExchangeAmountAsync(request);

            Assert.NotNull(result);
            Assert.NotNull(result.FromCurrency);
            Assert.NotNull(result.FromNetwork);
            Assert.NotNull(result.ToCurrency);
            Assert.NotNull(result.ToNetwork);
            Assert.NotNull(result.Flow);
            Assert.NotNull(result.MinAmount);


        }

        [Test]
        [TestCase("btc", "doge", FlowEnum.Standard, null, null)]
        public void GetMinimalExchangeAmountTest(string fromCurrency, string toCurrency, FlowEnum flow, string fromNetwork, string toNetwork)
        {
            var request = new MinimalExchangeRequest(fromCurrency, toCurrency, flow, fromNetwork, toNetwork);

            var result = _client.GetMinimalExchangeAmount(request);

            Assert.NotNull(result);
            Assert.NotNull(result.FromCurrency);
            Assert.NotNull(result.FromNetwork);
            Assert.NotNull(result.ToCurrency);
            Assert.NotNull(result.ToNetwork);
            Assert.NotNull(result.Flow);
            Assert.NotNull(result.MinAmount);


        }


        [TestCase("doge", "btc", FlowEnum.Standard, null, null)]

        public async Task GetExchangeRangeAsyncTest(string fromCurrency, string toCurrency, FlowEnum flow, string fromNetwork, string toNetwork)
        {

            var request = new ExchangeRangeRequest(fromCurrency, toCurrency, flow, fromNetwork, toNetwork);

            var result = await _client.GetExchangeRangeAsync(request);

            Assert.NotNull(result);
            Assert.NotNull(result.FromCurrency);
            Assert.NotNull(result.FromNetwork);
            Assert.NotNull(result.ToCurrency);
            Assert.NotNull(result.ToNetwork);
            Assert.NotNull(result.Flow);
            Assert.NotNull(result.MinAmount);


        }

        [Test]
        [TestCase("grs", "btc", FlowEnum.Standard, null, null)]
        public void GetExchangeRangeTest(string fromCurrency, string toCurrency, FlowEnum flow, string fromNetwork, string toNetwork)
        {

            var request = new ExchangeRangeRequest(fromCurrency, toCurrency, flow, fromNetwork, toNetwork);

            var result = _client.GetExchangeRange(request);

            Assert.NotNull(result);
            Assert.NotNull(result.FromCurrency);
            Assert.NotNull(result.FromNetwork);
            Assert.NotNull(result.ToCurrency);
            Assert.NotNull(result.ToNetwork);
            Assert.NotNull(result.Flow);
            Assert.NotNull(result.MinAmount);


        }

        [Test]
        [TestCase("dash", "doge", 0.142, null, FlowEnum.Standard, DirectionEnum.Direct, false, null, null)]
        [TestCase("eth", "btc", 0.1, 0.1, FlowEnum.FixedRate, DirectionEnum.Reverse, false, null, null)]
        [TestCase("btc", "eth", 0.2, null, FlowEnum.FixedRate, DirectionEnum.Direct, true, null, null)]
        public async Task GetEstimatedExchangeAmountAsyncTest(string fromCurrency, string toCurrency, decimal fromAmount, decimal toAmount, FlowEnum flow, DirectionEnum type, bool useRateId, string fromNetwork, string toNetwork)
        {

            var request = new EstimatedExchangeAmountRequest(fromCurrency, toCurrency, fromAmount, toAmount, flow, type, useRateId, fromNetwork, toNetwork);

            var result = await _client.GetEstimatedExchangeAmountAsync(request);
            Assert.NotNull(result);

            if (useRateId)
            {
                Assert.NotNull(result.FromCurrency);
                Assert.NotNull(result.FromNetwork);
                Assert.NotNull(result.ToCurrency);
                Assert.NotNull(result.ToNetwork);
                Assert.AreEqual(flow, result.Flow);
                Assert.AreEqual(type, result.Type);
                Assert.NotNull(result.RateId);
                Assert.NotNull(result.ValidUntil);
                Assert.Null(result.TransactionSpeedForecast);
                Assert.Null(result.warningMessage);
                Assert.NotNull(result.fromAmount);
                Assert.NotNull(result.ToAmount);
            }
            else
            {
                Assert.NotNull(result.FromCurrency);
                Assert.NotNull(result.FromNetwork);
                Assert.NotNull(result.ToCurrency);
                Assert.NotNull(result.ToNetwork);
                Assert.AreEqual(flow, result.Flow);
                Assert.AreEqual(type, result.Type);
                Assert.Null(result.RateId);
                Assert.Null(result.ValidUntil);
                Assert.NotNull(result.TransactionSpeedForecast);
                Assert.Null(result.warningMessage);
                Assert.NotNull(result.fromAmount);
                Assert.NotNull(result.ToAmount);

            }

        }

        [Test]
        [TestCase("ltc", "doge", 10, null, FlowEnum.Standard, DirectionEnum.Direct, false, null, null)]
        [TestCase("eth", "btc", 0.1, 0.1, FlowEnum.FixedRate, DirectionEnum.Reverse, false, null, null)]
        [TestCase("btc", "eth", 0.2, null, FlowEnum.FixedRate, DirectionEnum.Direct, true, null, null)]

        public void GetEstimatedExchangeAmountTest(string fromCurrency, string toCurrency, decimal fromAmount, decimal toAmount, FlowEnum flow, DirectionEnum type, bool useRateId, string fromNetwork, string toNetwork)
        {

            var request = new EstimatedExchangeAmountRequest(fromCurrency, toCurrency, fromAmount, toAmount, flow, type, useRateId, fromNetwork, toNetwork);

            var result = _client.GetEstimatedExchangeAmount(request);
            Assert.NotNull(result);


            if (useRateId)
            {
                Assert.NotNull(result.FromCurrency);
                Assert.NotNull(result.FromNetwork);
                Assert.NotNull(result.ToCurrency);
                Assert.NotNull(result.ToNetwork);
                Assert.NotNull(result.Flow);
                Assert.NotNull(result.Type);
                Assert.NotNull(result.RateId);
                Assert.NotNull(result.ValidUntil);
                Assert.Null(result.TransactionSpeedForecast);
                Assert.Null(result.warningMessage);
                Assert.NotNull(result.fromAmount);
                Assert.NotNull(result.ToAmount);
            }
            else
            {
                Assert.NotNull(result.FromCurrency);
                Assert.NotNull(result.FromNetwork);
                Assert.NotNull(result.ToCurrency);
                Assert.NotNull(result.ToNetwork);
                Assert.NotNull(result.Flow);
                Assert.NotNull(result.Type);
                Assert.Null(result.RateId);
                Assert.Null(result.ValidUntil);
                Assert.NotNull(result.TransactionSpeedForecast);
                Assert.Null(result.warningMessage);
                Assert.NotNull(result.fromAmount);
                Assert.NotNull(result.ToAmount);

            }

        }

        [Test]
        [TestCase( "doge", "D6CkMBAGs7pB3DJ2Q5qYTYUwvg8MpTCazX", true)]
        [TestCase( "doge", "D6CkMBAGs7pB3DJ2Q5qYTYUwvg8MpTCaz", false)]
        [TestCase( "Btc", "388bmweLPNYxEj7ZYP1jBgvt38aoxvFbnn", true)]
        [TestCase( "eth", "0x1a747bc6e51161B51E7141B99825fdF5fb382266", true)]
        public async Task ValidateAddressAsyncTest(string currency, string address, bool expected)
        {
            var request = new AddressValidationRequest(currency, address);

            var result = await _client.ValidateAddressAsync(request);

            Assert.NotNull(result);
            Assert.AreEqual(expected, result.Result);



        }

        [Test]
        [TestCase("doge", "D6CkMBAGs7pB3DJ2Q5qYTYUwvg8MpTCazX", true)]
        [TestCase("doge", "D6CkMBAGs7pB3DJ2Q5qYTYUwvg8MpTCaz", false)]
        [TestCase("Btc", "388bmweLPNYxEj7ZYP1jBgvt38aoxvFbnn", true)]
        [TestCase("eth", "0x1a747bc6e51161B51E7141B99825fdF5fb382266", true)]
        public void ValidateAddressTest(string currency, string address, bool expected)
        {

            var request = new AddressValidationRequest(currency, address);

            var result = _client.ValidateAddress(request);
            Assert.NotNull(result);
            Assert.AreEqual(expected, result.Result);
        }

        [Test]
        [TestCase("BTC",true)]
        [TestCase("doge", true)]
        [TestCase("dash", false)]
        [TestCase("ltc", false)]
        [TestCase("eth", true)]
        public void IsCurrencyValidationAvailable(string currency, bool expected)
        {
            var request = new AddressValidationRequest(currency, "SomeAdress");
            Assert.AreEqual(expected, request.IsValidationAvailable);
        }

        [Test]
        public async Task GetFioAddressesAsyncTest()
        {

            var request = new FioAddressesRequest("ShouldNOtExist");

            var result = await _client.GetFioAddressesAsync(request);
            Assert.NotNull(result);
            Assert.False(result.Success);

        }

        [Test]
        public void GetFioAddressesTest()
        {
            var request = new FioAddressesRequest("ShouldNOtExist");

            var result = _client.GetFioAddresses(request);
            Assert.NotNull(result);
            Assert.False(result.Success);

        }

        [Test]
        [TestCase("usd", "btc", 200, null, DirectionEnum.Direct)]
        public async Task GetMarketEstimatedInfosAsyncTest(string fromCurrency, string toCurrency, decimal fromAmount, decimal toAmount, DirectionEnum type)
        {

            var request = new MarketEstimatedRequest(fromCurrency, toCurrency, fromAmount, toAmount, type);

            var result = await _client.GetMarketEstimatedInfosAsync(request);
            Assert.NotNull(result);

        }

        [Test]
        [TestCase("usd", "eth", 100, null, DirectionEnum.Direct)]
        public void GetMarketEstimatedInfosTest(string fromCurrency, string toCurrency, decimal fromAmount, decimal toAmount, DirectionEnum type)
        {
            var request = new MarketEstimatedRequest(fromCurrency, toCurrency, fromAmount, toAmount, type);
            var result = _client.GetMarketEstimatedInfos(request);
            Assert.NotNull(result);

        }

        [Test]
        [TestCase("ltc", "doge", 0.1, "D6CkMBAGs7pB3DJ2Q5qYTYUwvg8MpTCazX")]
        public async Task CreateExchangeTransactionAsyncTest(string fromCurrency, string toCurrency, decimal fromAmount, string address)
        {

            var request = new TransactionRequest(fromCurrency, toCurrency, fromAmount, address);
            var result = await _client.CreateExchangeTransactionAsync(request);
            Assert.NotNull(result);
            Assert.False(string.IsNullOrEmpty(result.PayinAddress));
            Assert.Null(result.PayinExtraId);
            Assert.False(string.IsNullOrEmpty(result.PayoutAddress));
            Assert.True(string.IsNullOrEmpty(result.PayoutExtraId));
            Assert.Null(result.PayoutExtraIdName);
            Assert.False(string.IsNullOrEmpty(result.Id));
            Assert.False(string.IsNullOrEmpty(result.FromCurrency));
            Assert.False(string.IsNullOrEmpty(result.FromNetwork));
            Assert.False(string.IsNullOrEmpty(result.Id));
            Assert.True(string.IsNullOrEmpty(result.RefundAddress));
            Assert.True(string.IsNullOrEmpty(result.RefundExtraId));
            Assert.False(string.IsNullOrEmpty(result.ToCurrency));
            Assert.False(string.IsNullOrEmpty(result.ToNetwork));

        }

        [Test]
        [TestCase("ltc", "grs", 0.1, "3NrV5Lfu8Svejvppwhu3YdvMKKsEYxUd8L")]
        public void CreateExchangeTransactionTest(string fromCurrency, string toCurrency, decimal fromAmount, string address)
        {

            var request = new TransactionRequest(fromCurrency, toCurrency, fromAmount, address);

            var result = _client.CreateExchangeTransaction(request);

            Assert.NotNull(result);
            Assert.False(string.IsNullOrEmpty(result.PayinAddress));
            Assert.Null(result.PayinExtraId);
            Assert.False(string.IsNullOrEmpty(result.PayoutAddress));
            Assert.True(string.IsNullOrEmpty(result.PayoutExtraId));
            Assert.Null(result.PayoutExtraIdName);
            Assert.False(string.IsNullOrEmpty(result.Id));
            Assert.False(string.IsNullOrEmpty(result.FromCurrency));
            Assert.False(string.IsNullOrEmpty(result.FromNetwork));
            Assert.False(string.IsNullOrEmpty(result.Id));
            Assert.True(string.IsNullOrEmpty(result.RefundAddress));
            Assert.True(string.IsNullOrEmpty(result.RefundExtraId));
            Assert.False(string.IsNullOrEmpty(result.ToCurrency));
            Assert.False(string.IsNullOrEmpty(result.ToNetwork));

        }

        [Test]

        public async Task GetTransactionStatusAsyncTest()
        {
            var request = new TransactionStatusRequest("YourID");

            var result = await _client.GetTransactionStatusAsync(request);

            Assert.NotNull(result);

        }

        [Test]

        public void GetTransactionStatusTest()
        {
            var request = new TransactionStatusRequest("YourID");

            var result = _client.GetTransactionStatus(request);

            Assert.NotNull(result);
  
        }

        [Test]
        [TestCase("new", TransactionStatusEnum.New)]
        [TestCase("Waiting", TransactionStatusEnum.Waiting)]
        [TestCase("confirming", TransactionStatusEnum.Confirming)]
        [TestCase("Exchanging", TransactionStatusEnum.Exchanging)]
        [TestCase("sending", TransactionStatusEnum.Sending)]
        [TestCase("finished", TransactionStatusEnum.Finished)]
        [TestCase("failed", TransactionStatusEnum.Failed)]
        [TestCase("Verifying", TransactionStatusEnum.Verifying)]
        [TestCase("refunded", TransactionStatusEnum.Refunded)]
        [TestCase("ThisEnumNotExist", TransactionStatusEnum.UnKnown)]
        [TestCase(null, TransactionStatusEnum.UnKnown)]
        public void ChangeNowConverterStringToEnumTests(string value, TransactionStatusEnum expected)
        {
            Assert.AreEqual(expected, TransactionStatusEnumConverter.StringToEnum(value));
        }

        [Test]
        [TestCase("new", TransactionStatusEnum.New)]
        [TestCase("waiting", TransactionStatusEnum.Waiting)]
        [TestCase("confirming", TransactionStatusEnum.Confirming)]
        [TestCase("exchanging", TransactionStatusEnum.Exchanging)]
        [TestCase("sending", TransactionStatusEnum.Sending)]
        [TestCase("finished", TransactionStatusEnum.Finished)]
        [TestCase("failed", TransactionStatusEnum.Failed)]
        [TestCase("verifying", TransactionStatusEnum.Verifying)]
        [TestCase("refunded", TransactionStatusEnum.Refunded)]
        [TestCase("unknown", TransactionStatusEnum.UnKnown)]
        public void ChangeNowConverterEnumToStringTest(string expected, TransactionStatusEnum value)
        {
            Assert.AreEqual(expected, TransactionStatusEnumConverter.EnumToString(value));
        }
    }
}