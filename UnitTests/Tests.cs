using ChangeNowApi_V2;
using ChangeNowApi_V2.Dto;
using ChangeNowApi_V2.Enums;
using ChangeNowApi_V2.Helper;
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
        private const string _apiKey = "your API Key";

        /// <summary>
        /// You have to use a valid transactionID. 
        /// This could have expired and the TransactionStatus tests will fail
        /// </summary>
        private static string _transactionID = "eba706364c7e6c";

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
        [TestCase(true, true, true, true, Flow.Standard)]
        [TestCase(false, true, true, true, Flow.Standard)]
        [TestCase(false, false, false, true, Flow.Standard)]
        [TestCase(false, false, false, false, Flow.Standard)]
        [TestCase(false, true, false, false, Flow.Standard)]
        [TestCase(false, false, true, false, Flow.Standard)]
        public async Task GetListOfAvailableCurrenciesAsyncTest(bool objIsNull, bool sell, bool buy, bool active, string flow)
        {
            CurrencyRequest request;

            if (objIsNull)
            {
                request = null;
            }
            else
            {
                request = new CurrencyRequest() { Active = active, Buy = buy, Flow = flow, Sell = sell };

            }


            var result = await _client.GetListOfAvailableCurrenciesAsync(request);
            Assert.NotNull(result);
            Assert.True(result.Count > 0);


        }

        [Test]
        [TestCase(true, true, true, true, Flow.Standard)]
        [TestCase(false, true, true, true, Flow.Standard)]
        [TestCase(false, false, false, true, Flow.Standard)]
        [TestCase(false, false, false, false, Flow.Standard)]
        [TestCase(false, true, false, false, Flow.Standard)]
        [TestCase(false, false, true, false, Flow.Standard)]
        public void GetListOfAvailableCurrenciesTest(bool objIsNull, bool sell, bool buy, bool active, string flow)
        {
            CurrencyRequest request;

            if (objIsNull)
            {
                request = null;
            }
            else
            {
                request = new CurrencyRequest() { Active = active, Buy = buy, Flow = flow, Sell = sell };
            }


            var result = _client.GetListOfAvailableCurrencies(request);
            Assert.NotNull(result);
            Assert.True(result.Count > 0);

        }

        [Test]
        [TestCase(true, null, null, null, null, Flow.Standard)]
        [TestCase(false, "btc", null, "doge", null, Flow.Standard)]
        public async Task GetMinimalExchangeAmountAsyncTest(bool objIsNull, string fromCurrency, string fromNetwork, string toCurrency, string toNetwork, string flow)
        {
            MinimalExchangeRequest request;

            if (objIsNull)
            {
                request = null;
            }
            else
            {
                request = new MinimalExchangeRequest()
                {
                    FromCurrency = fromCurrency,
                    FromNetwork = fromNetwork,
                    ToCurrency = toCurrency,
                    ToNetwork = toNetwork,
                    Flow = flow
                };
            }


            var result = await _client.GetMinimalExchangeAmountAsync(request);
            Assert.NotNull(result);

            if (objIsNull)
            {
                Assert.Null(result.FromCurrency);
                Assert.Null(result.FromNetwork);
                Assert.Null(result.ToCurrency);
                Assert.Null(result.ToNetwork);
                Assert.Null(result.Flow);
                Assert.Null(result.MinAmount);
            }
            else
            {
                Assert.NotNull(result.FromCurrency);
                Assert.NotNull(result.FromNetwork);
                Assert.NotNull(result.ToCurrency);
                Assert.NotNull(result.ToNetwork);
                Assert.NotNull(result.Flow);
                Assert.NotNull(result.MinAmount);
            }

        }

        [Test]
        [TestCase(true, null, null, null, null, Flow.Standard)]
        [TestCase(false, "btc", null, "doge", null, Flow.Standard)]
        public void GetMinimalExchangeAmountTest(bool objIsNull, string fromCurrency, string fromNetwork, string toCurrency, string toNetwork, string flow)
        {
            MinimalExchangeRequest request;

            if (objIsNull)
            {
                request = null;
            }
            else
            {
                request = new MinimalExchangeRequest()
                {
                    FromCurrency = fromCurrency,
                    FromNetwork = fromNetwork,
                    ToCurrency = toCurrency,
                    ToNetwork = toNetwork,
                    Flow = flow
                };
            }


            var result = _client.GetMinimalExchangeAmount(request);
            Assert.NotNull(result);

            if (objIsNull)
            {
                Assert.Null(result.FromCurrency);
                Assert.Null(result.FromNetwork);
                Assert.Null(result.ToCurrency);
                Assert.Null(result.ToNetwork);
                Assert.Null(result.Flow);
                Assert.Null(result.MinAmount);
            }
            else
            {
                Assert.NotNull(result.FromCurrency);
                Assert.NotNull(result.FromNetwork);
                Assert.NotNull(result.ToCurrency);
                Assert.NotNull(result.ToNetwork);
                Assert.NotNull(result.Flow);
                Assert.NotNull(result.MinAmount);
            }

        }

        [Test]
        [TestCase(true, null, null, null, null, Flow.Standard)]
        [TestCase(false, "eth", null, "btc", null, Flow.Standard)]
        public async Task GetExchangeRangeAsyncTest(bool objIsNull, string fromCurrency, string fromNetwork, string toCurrency, string toNetwork, string flow)
        {
            ExchangeRangeRequest request;

            if (objIsNull)
            {
                request = null;
            }
            else
            {
                request = new ExchangeRangeRequest()
                {
                    FromCurrency = fromCurrency,
                    FromNetwork = fromNetwork,
                    ToCurrency = toCurrency,
                    ToNetwork = toNetwork,
                    Flow = flow
                };
            }


            var result = await _client.GetExchangeRangeAsync(request);
            Assert.NotNull(result);

            if (objIsNull)
            {
                Assert.Null(result.FromCurrency);
                Assert.Null(result.FromNetwork);
                Assert.Null(result.ToCurrency);
                Assert.Null(result.ToNetwork);
                Assert.Null(result.Flow);
                Assert.Null(result.MinAmount);
                Assert.Null(result.MaxAmount);
            }
            else
            {
                Assert.NotNull(result.FromCurrency);
                Assert.NotNull(result.FromNetwork);
                Assert.NotNull(result.ToCurrency);
                Assert.NotNull(result.ToNetwork);
                Assert.NotNull(result.Flow);
                Assert.NotNull(result.MinAmount);
            }

        }

        [Test]
        [TestCase(true, null, null, null, null, Flow.Standard)]
        [TestCase(false, "eth", null, "btc", null, Flow.Standard)]
        public void GetExchangeRangeTest(bool objIsNull, string fromCurrency, string fromNetwork, string toCurrency, string toNetwork, string flow)
        {
            ExchangeRangeRequest request;

            if (objIsNull)
            {
                request = null;
            }
            else
            {
                request = new ExchangeRangeRequest()
                {
                    FromCurrency = fromCurrency,
                    FromNetwork = fromNetwork,
                    ToCurrency = toCurrency,
                    ToNetwork = toNetwork,
                    Flow = flow
                };
            }


            var result = _client.GetExchangeRange(request);
            Assert.NotNull(result);

            if (objIsNull)
            {
                Assert.Null(result.FromCurrency);
                Assert.Null(result.FromNetwork);
                Assert.Null(result.ToCurrency);
                Assert.Null(result.ToNetwork);
                Assert.Null(result.Flow);
                Assert.Null(result.MinAmount);
                Assert.Null(result.MaxAmount);
            }
            else
            {
                Assert.NotNull(result.FromCurrency);
                Assert.NotNull(result.FromNetwork);
                Assert.NotNull(result.ToCurrency);
                Assert.NotNull(result.ToNetwork);
                Assert.NotNull(result.Flow);
                Assert.NotNull(result.MinAmount);
            }

        }

        [Test]
        [TestCase(true, null, null, null, null, null, null, Flow.Standard, Direction.Direct, false)]
        [TestCase(false, "ltc", "doge", "10", null, null, null, Flow.Standard, Direction.Direct, false)]
        [TestCase(false, "eth", "btc", "0.1", "0.1", null, null, Flow.FixedRate, Direction.Reverse, false)]
        [TestCase(false, "btc", "eth", "0.2", null, null, null, Flow.FixedRate, Direction.Direct, true)]
        public async Task GetEstimatedExchangeAmountAsyncTest(bool objIsNull, string fromCurrency, string toCurrency, string fromAmount, string toAmount, string fromNetwork, string toNetwork, string flow, string type, bool useRateId)
        {
            EstimatedExchangeAmountRequest request;

            if (objIsNull)
            {
                request = null;
            }
            else
            {
                request = new EstimatedExchangeAmountRequest()
                {
                    FromCurrency = fromCurrency,
                    ToCurrency = toCurrency,
                    FromAmount = fromAmount,
                    ToAmount = toAmount,
                    FromNetwork = fromNetwork,
                    ToNetwork = toNetwork,
                    Flow = flow,
                    Type = type,
                    UseRateId = useRateId
                };
            }


            var result = await _client.GetEstimatedExchangeAmountAsync(request);
            Assert.NotNull(result);

            if (objIsNull)
            {
                Assert.Null(result.FromCurrency);
                Assert.Null(result.FromNetwork);
                Assert.Null(result.ToCurrency);
                Assert.Null(result.ToNetwork);
                Assert.Null(result.Flow);
                Assert.AreEqual(result.Type, Direction.Direct); // Is default direct
                Assert.Null(result.RateId);
                Assert.Null(result.ValidUntil);
                Assert.Null(result.TransactionSpeedForecast);
                Assert.Null(result.warningMessage);
                Assert.AreEqual(result.fromAmount, 0); // default 0
                Assert.Null(result.ToAmount);

            }
            else if (!objIsNull && useRateId)
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
        [TestCase(true, null, null, null, null, null, null, Flow.Standard, Direction.Direct, false)]
        [TestCase(false, "ltc", "doge", "10", null, null, null, Flow.Standard, Direction.Direct, false)]
        [TestCase(false, "eth", "btc", "0.1", "0.1", null, null, Flow.FixedRate, Direction.Reverse, false)]
        [TestCase(false, "btc", "eth", "0.2", null, null, null, Flow.FixedRate, Direction.Direct, true)]

        public void GetEstimatedExchangeAmountTest(bool objIsNull, string fromCurrency, string toCurrency, string fromAmount, string toAmount, string fromNetwork, string toNetwork, string flow, string type, bool useRateId)
        {
            EstimatedExchangeAmountRequest request;

            if (objIsNull)
            {
                request = null;
            }
            else
            {
                request = new EstimatedExchangeAmountRequest()
                {
                    FromCurrency = fromCurrency,
                    ToCurrency = toCurrency,
                    FromAmount = fromAmount,
                    ToAmount = toAmount,
                    FromNetwork = fromNetwork,
                    ToNetwork = toNetwork,
                    Flow = flow,
                    Type = type,
                    UseRateId = useRateId
                };
            }


            var result = _client.GetEstimatedExchangeAmount(request);
            Assert.NotNull(result);

            if (objIsNull)
            {
                Assert.Null(result.FromCurrency);
                Assert.Null(result.FromNetwork);
                Assert.Null(result.ToCurrency);
                Assert.Null(result.ToNetwork);
                Assert.Null(result.Flow);
                Assert.AreEqual(result.Type, Direction.Direct); // Is default direct
                Assert.Null(result.RateId);
                Assert.Null(result.ValidUntil);
                Assert.Null(result.TransactionSpeedForecast);
                Assert.Null(result.warningMessage);
                Assert.AreEqual(result.fromAmount, 0); // default 0
                Assert.Null(result.ToAmount);

            }
            else if (!objIsNull && useRateId)
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
        [TestCase(false, "doge", "D6CkMBAGs7pB3DJ2Q5qYTYUwvg8MpTCazX", true)]
        [TestCase(false, "doge", "D6CkMBAGs7pB3DJ2Q5qYTYUwvg8MpTCaz", false)]
        [TestCase(false, "dash", "XuvkS6AsfZ59LVUbEe4WDm26XFSPobvYwe", true)]
        [TestCase(false, "Btc", "388bmweLPNYxEj7ZYP1jBgvt38aoxvFbnn", true)]
        [TestCase(false, "eth", "0x1a747bc6e51161B51E7141B99825fdF5fb382266", true)]
        [TestCase(false, "LTC", "M8jujfHsvvqai9Qe4qRevDKfU7nB83MRS5", true)]
        public async Task ValidateAddressAsyncTest(bool objIsNull, string currency, string address, bool expected)
        {
            AddressValidationRequest request;

            if (objIsNull)
            {
                request = null;
            }
            else
            {
                request = new AddressValidationRequest()
                {
                    Curreny = currency,
                    Adress = address
                };
            }


            var result = await _client.ValidateAddressAsync(request);
            Assert.NotNull(result);

            if (objIsNull)
            {
                Assert.NotNull(result.Message);
                Assert.NotNull(result.Result);
            }
            else
            {
                Assert.AreEqual(expected, result.Result);
            }


        }

        [Test]
        [TestCase(false, "doge", "D6CkMBAGs7pB3DJ2Q5qYTYUwvg8MpTCazX", true)]
        [TestCase(false, "doge", "D6CkMBAGs7pB3DJ2Q5qYTYUwvg8MpTCaz", false)]
        [TestCase(false, "dash", "XuvkS6AsfZ59LVUbEe4WDm26XFSPobvYwe", true)]
        [TestCase(false, "Btc", "388bmweLPNYxEj7ZYP1jBgvt38aoxvFbnn", true)]
        [TestCase(false, "eth", "0x1a747bc6e51161B51E7141B99825fdF5fb382266", true)]
        [TestCase(false, "LTC", "M8jujfHsvvqai9Qe4qRevDKfU7nB83MRS5", true)]
        public void ValidateAddressTest(bool objIsNull, string currency, string address, bool expected)
        {
            AddressValidationRequest request;

            if (objIsNull)
            {
                request = null;
            }
            else
            {
                request = new AddressValidationRequest()
                {
                    Curreny = currency,
                    Adress = address
                };
            }


            var result = _client.ValidateAddress(request);
            Assert.NotNull(result);

            if (objIsNull)
            {
                Assert.NotNull(result.Message);
                Assert.NotNull(result.Result);
            }
            else
            {
                Assert.AreEqual(expected, result.Result);
            }


        }

        [Test]
        [TestCase(true, null)]
        [TestCase(false, "ShouldNOtExist")]
        public async Task GetFioAddressesAsyncTest(bool objIsNull, string name)
        {
            FioAddressesRequest request;

            if (objIsNull)
            {
                request = null;
            }
            else
            {
                request = new FioAddressesRequest()
                {
                    Name = name
                };
            }


            var result = await _client.GetFioAddressesAsync(request);
            Assert.NotNull(result);
            Assert.False(result.Success);

        }

        [Test]
        [TestCase(true, null)]
        [TestCase(false, "ShouldNOtExist")]
        public void GetFioAddressesTest(bool objIsNull, string name)
        {
            FioAddressesRequest request;

            if (objIsNull)
            {
                request = null;
            }
            else
            {
                request = new FioAddressesRequest()
                {
                    Name = name
                };
            }


            var result = _client.GetFioAddresses(request);
            Assert.NotNull(result);
            Assert.False(result.Success);

        }

        [Test]
        [TestCase(true, null, null, null, null, null)]
        [TestCase(false, "btc", "eth", "0.1", null, null)]
        public async Task GetMarketEstimatedInfosAsyncTest(bool objIsNull, string fromCurrency, string toCurrency, string fromAmount, string toAmount, string type)
        {
            MarketEstimatedRequest request;

            if (objIsNull)
            {
                request = null;
            }
            else
            {
                request = new MarketEstimatedRequest()
                {
                    FromCurrency = fromCurrency,
                    ToCurrency = toCurrency,
                    FromAmount = fromAmount,
                    ToAmount = toAmount,
                    Type = type

                };
            }

            var result = await _client.GetMarketEstimatedInfosAsync(request);
            Assert.NotNull(result);

        }

        [Test]
        [TestCase(true, null, null, null, null, null)]
        [TestCase(false, "btc", "eth", "0.1", null, null)]
        public void GetMarketEstimatedInfosTest(bool objIsNull, string fromCurrency, string toCurrency, string fromAmount, string toAmount, string type)
        {
            MarketEstimatedRequest request;

            if (objIsNull)
            {
                request = null;
            }
            else
            {
                request = new MarketEstimatedRequest()
                {
                    FromCurrency = fromCurrency,
                    ToCurrency = toCurrency,
                    FromAmount = fromAmount,
                    ToAmount = toAmount,
                    Type = type

                };
            }

            var result = _client.GetMarketEstimatedInfos(request);
            Assert.NotNull(result);

        }

        [Test]
        [TestCase(true, null, null, null, null)]
        [TestCase(false, "ltc", "doge", "0.1", "D6CkMBAGs7pB3DJ2Q5qYTYUwvg8MpTCazX")]
        public async Task CreateExchangeTransactionAsyncTest(bool objIsNull, string fromCurrency, string toCurrency, string fromAmount, string address)
        {
            TransactionRequest request;

            if (objIsNull)
            {
                request = null;
            }
            else
            {
                request = new TransactionRequest()
                {
                    FromCurrency = fromCurrency,
                    ToCurrency = toCurrency,
                    FromAmount = fromAmount,
                    Address = address,
                    FromNetwork = fromCurrency,
                    ToNetwork = toCurrency
                };
            }

            var result = await _client.CreateExchangeTransactionAsync(request);
            Assert.NotNull(result);

            if (objIsNull)
            {
                Assert.Null(result.PayinAddress);
                Assert.Null(result.PayinExtraId);
                Assert.Null(result.PayoutAddress);
                Assert.Null(result.PayoutExtraId);
                Assert.Null(result.PayoutExtraIdName);
                Assert.Null(result.Id);
                Assert.True(string.IsNullOrEmpty(result.Flow));
                Assert.True(string.IsNullOrEmpty(result.FromCurrency));
                Assert.True(string.IsNullOrEmpty(result.FromNetwork));
                Assert.True(string.IsNullOrEmpty(result.Id));
                Assert.True(string.IsNullOrEmpty(result.RefundAddress));
                Assert.True(string.IsNullOrEmpty(result.RefundExtraId));
                Assert.True(string.IsNullOrEmpty(result.ToCurrency));
                Assert.True(string.IsNullOrEmpty(result.ToNetwork));
            }
            else
            {
                Assert.False(string.IsNullOrEmpty(result.PayinAddress));
                Assert.Null(result.PayinExtraId);
                Assert.False(string.IsNullOrEmpty(result.PayoutAddress));
                Assert.True(string.IsNullOrEmpty(result.PayoutExtraId));
                Assert.Null(result.PayoutExtraIdName);
                Assert.False(string.IsNullOrEmpty(result.Id));
                Assert.False(string.IsNullOrEmpty(result.Flow));
                Assert.False(string.IsNullOrEmpty(result.FromCurrency));
                Assert.False(string.IsNullOrEmpty(result.FromNetwork));
                Assert.False(string.IsNullOrEmpty(result.Id));
                Assert.True(string.IsNullOrEmpty(result.RefundAddress));
                Assert.True(string.IsNullOrEmpty(result.RefundExtraId));
                Assert.False(string.IsNullOrEmpty(result.ToCurrency));
                Assert.False(string.IsNullOrEmpty(result.ToNetwork));
            }

            //Save id for the next test
            if (!string.IsNullOrEmpty(result.Id))
            {
                _transactionID = result.Id;
            }

        }

        [Test]
        [TestCase(true, null, null, null, null)]
        [TestCase(false, "ltc", "grs", "0.1", "3NrV5Lfu8Svejvppwhu3YdvMKKsEYxUd8L")]
        public void CreateExchangeTransactionTest(bool objIsNull, string fromCurrency, string toCurrency, string fromAmount, string address)
        {
            TransactionRequest request;

            if (objIsNull)
            {
                request = null;
            }
            else
            {
                request = new TransactionRequest()
                {
                    FromCurrency = fromCurrency,
                    ToCurrency = toCurrency,
                    FromAmount = fromAmount,
                    Address = address,
                    FromNetwork = fromCurrency,
                    ToNetwork = toCurrency
                };
            }

            var result = _client.CreateExchangeTransaction(request);
            Assert.NotNull(result);

            if (objIsNull)
            {
                Assert.Null(result.PayinAddress);
                Assert.Null(result.PayinExtraId);
                Assert.Null(result.PayoutAddress);
                Assert.Null(result.PayoutExtraId);
                Assert.Null(result.PayoutExtraIdName);
                Assert.Null(result.Id);
                Assert.True(string.IsNullOrEmpty(result.Flow));
                Assert.True(string.IsNullOrEmpty(result.FromCurrency));
                Assert.True(string.IsNullOrEmpty(result.FromNetwork));
                Assert.True(string.IsNullOrEmpty(result.Id));
                Assert.True(string.IsNullOrEmpty(result.RefundAddress));
                Assert.True(string.IsNullOrEmpty(result.RefundExtraId));
                Assert.True(string.IsNullOrEmpty(result.ToCurrency));
                Assert.True(string.IsNullOrEmpty(result.ToNetwork));
            }
            else
            {
                Assert.False(string.IsNullOrEmpty(result.PayinAddress));
                Assert.Null(result.PayinExtraId);
                Assert.False(string.IsNullOrEmpty(result.PayoutAddress));
                Assert.True(string.IsNullOrEmpty(result.PayoutExtraId));
                Assert.Null(result.PayoutExtraIdName);
                Assert.False(string.IsNullOrEmpty(result.Id));
                Assert.False(string.IsNullOrEmpty(result.Flow));
                Assert.False(string.IsNullOrEmpty(result.FromCurrency));
                Assert.False(string.IsNullOrEmpty(result.FromNetwork));
                Assert.False(string.IsNullOrEmpty(result.Id));
                Assert.True(string.IsNullOrEmpty(result.RefundAddress));
                Assert.True(string.IsNullOrEmpty(result.RefundExtraId));
                Assert.False(string.IsNullOrEmpty(result.ToCurrency));
                Assert.False(string.IsNullOrEmpty(result.ToNetwork));
            }
        }

        [Test]
        [TestCase(true, true)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public async Task GetTransactionStatusAsyncTest(bool objIsNull, bool function)
        {
            TransactionStatusRequest request = new TransactionStatusRequest() { Id = _transactionID };

            TransactionStatusResponse result;
            if (function)
            {
                if (objIsNull)
                {
                    request = null;
                }
                result = await _client.GetTransactionStatusAsync(request);
            }
            else
            {

                result = await _client.GetTransactionStatusAsync(_transactionID);

            }

            Assert.NotNull(result);

            if (objIsNull)
            {
                Assert.False(result.ActionsAvailable);
                Assert.Null(result.AmountFrom);
                Assert.Null(result.AmountTo);
                Assert.Null(result.CreatedAt);
                Assert.Null(result.FromCurrency);
                Assert.Null(result.ExpectedAmountFrom);
                Assert.Null(result.PayoutAddress);
            }
            else
            {
                Assert.False(string.IsNullOrEmpty(result.PayinAddress));
                Assert.False(result.ActionsAvailable);
                Assert.False(string.IsNullOrEmpty(result.PayoutAddress));
                Assert.NotNull(result.ExpectedAmountFrom);
                Assert.False(string.IsNullOrEmpty(result.Status));
                Assert.True(string.IsNullOrEmpty(result.PayinHash));
                Assert.True(string.IsNullOrEmpty(result.PayoutHash));
                Assert.False(string.IsNullOrEmpty(result.FromCurrency));
                Assert.False(string.IsNullOrEmpty(result.ToCurrency));
                Assert.Null(result.AmountTo);
                Assert.Null(result.AmountFrom);
                Assert.NotNull(result.ExpectedAmountTo);
                Assert.Null(result.DepositReceivedAt);
                Assert.NotNull(result.CreatedAt);
            }


        }

        [Test]
        [TestCase(true, true)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public void GetTransactionStatusTest(bool objIsNull, bool function)
        {
            TransactionStatusRequest request = new TransactionStatusRequest() { Id = _transactionID };

            TransactionStatusResponse result;
            if (function)
            {
                if (objIsNull)
                {
                    request = null;
                }
                result = _client.GetTransactionStatus(request);
            }
            else
            {

                result = _client.GetTransactionStatus(_transactionID);

            }

            Assert.NotNull(result);

            if (objIsNull)
            {
                Assert.False(result.ActionsAvailable);
                Assert.Null(result.AmountFrom);
                Assert.Null(result.AmountTo);
                Assert.Null(result.CreatedAt);
                Assert.Null(result.FromCurrency);
                Assert.Null(result.ExpectedAmountFrom);
                Assert.Null(result.PayoutAddress);
            }
            else
            {
                Assert.False(string.IsNullOrEmpty(result.PayinAddress));
                Assert.False(result.ActionsAvailable);
                Assert.False(string.IsNullOrEmpty(result.PayoutAddress));
                Assert.NotNull(result.ExpectedAmountFrom);
                Assert.False(string.IsNullOrEmpty(result.Status));
                Assert.True(string.IsNullOrEmpty(result.PayinHash));
                Assert.True(string.IsNullOrEmpty(result.PayoutHash));
                Assert.False(string.IsNullOrEmpty(result.FromCurrency));
                Assert.False(string.IsNullOrEmpty(result.ToCurrency));
                Assert.Null(result.AmountTo);
                Assert.Null(result.AmountFrom);
                Assert.NotNull(result.ExpectedAmountTo);
                Assert.Null(result.DepositReceivedAt);
                Assert.NotNull(result.CreatedAt);
            }


        }

        [Test]
        [TestCase("new", TransactionStatus.New)]
        [TestCase("Waiting", TransactionStatus.Waiting)]
        [TestCase("confirming", TransactionStatus.Confirming)]
        [TestCase("Exchanging", TransactionStatus.Exchanging)]
        [TestCase("sending", TransactionStatus.Sending)]
        [TestCase("finished", TransactionStatus.Finished)]
        [TestCase("failed", TransactionStatus.Failed)]
        [TestCase("Verifying", TransactionStatus.Verifying)]
        [TestCase("refunded", TransactionStatus.Refunded)]
        [TestCase("ThisEnumNotExist",TransactionStatus.UnKnown)]
        [TestCase(null, TransactionStatus.UnKnown)]
        public void ChangeNowConverterStringToEnumTests(string value, TransactionStatus expected)
        {
            Assert.AreEqual(expected, ChangeNowConverter.StringToTransactionStatus(value));
        }

        [Test]
        [TestCase("new", TransactionStatus.New)]
        [TestCase("waiting", TransactionStatus.Waiting)]
        [TestCase("confirming", TransactionStatus.Confirming)]
        [TestCase("exchanging", TransactionStatus.Exchanging)]
        [TestCase("sending", TransactionStatus.Sending)]
        [TestCase("finished", TransactionStatus.Finished)]
        [TestCase("failed", TransactionStatus.Failed)]
        [TestCase("verifying", TransactionStatus.Verifying)]
        [TestCase("refunded", TransactionStatus.Refunded)]
        [TestCase("unknown", TransactionStatus.UnKnown)]
        public void ChangeNowConverterEnumToStringTest(string expected, TransactionStatus value)
        {
            Assert.AreEqual(expected, ChangeNowConverter.TransactionStatusToString(value));
        }
    }
}