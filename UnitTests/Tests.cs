using ChangeNowApi_V2;
using ChangeNowApi_V2.Dto;
using ChangeNowApi_V2.Enums;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTests
{
    public class Tests
    {
        ChangeNowClient client;

        /// <summary>
        /// Note! You have to use your own ApiKey
        /// </summary>
        private const string ApiKey = "96281cfe083eba5afec4afecf7859a1198e572a4f26f54f66a502085278de148";

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            client = new ChangeNowClient(ApiKey);
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


            var result = await client.GetListOfAvailableCurrenciesAsync(request);
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


            var result = client.GetListOfAvailableCurrencies(request);
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


            var result = await client.GetMinimalExchangeAmountAsync(request);
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


            var result = client.GetMinimalExchangeAmount(request);
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


            var result = await client.GetExchangeRangeAsync(request);
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


            var result = client.GetExchangeRange(request);
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
        [TestCase(true, null, null, null, null,null,null, Flow.Standard,Direction.Direct, false)]
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


            var result = await client.GetEstimatedExchangeAmountAsync(request);
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


            var result = client.GetEstimatedExchangeAmount(request);
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
            else if(!objIsNull && useRateId)
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
        [TestCase(true, null,null,true)]
        [TestCase(false, "doge", "D6CkMBAGs7pB3DJ2Q5qYTYUwvg8MpTCazX", true)]
        [TestCase(false, "doge", "D6CkMBAGs7pB3DJ2Q5qYTYUwvg8MpTCaz", false)]
        [TestCase(false, "dash", "XuvkS6AsfZ59LVUbEe4WDm26XFSPobvYwe", false)]
        [TestCase(false, "btc", "388bmweLPNYxEj7ZYP1jBgvt38aoxvFbnn", true)]
        [TestCase(false, "eth", "0x1a747bc6e51161B51E7141B99825fdF5fb382266", true)]
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
                    Adresse = address
                };
            }


            var result = await client.ValidateAddressAsync(request);
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
        [TestCase(true, null, null, true)]
        [TestCase(false, "doge", "D6CkMBAGs7pB3DJ2Q5qYTYUwvg8MpTCazX", true)]
        [TestCase(false, "doge", "D6CkMBAGs7pB3DJ2Q5qYTYUwvg8MpTCaz", false)]
        [TestCase(false, "dash", "XuvkS6AsfZ59LVUbEe4WDm26XFSPobvYwe", false)]
        [TestCase(false, "btc", "388bmweLPNYxEj7ZYP1jBgvt38aoxvFbnn", true)]
        [TestCase(false, "eth", "0x1a747bc6e51161B51E7141B99825fdF5fb382266", true)]
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
                    Adresse = address
                };
            }


            var result = client.ValidateAddress(request);
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


            var result = await client.GetFioAddressesAsync(request);
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


            var result = client.GetFioAddresses(request);
            Assert.NotNull(result);
            Assert.False(result.Success);

        }

        [Test]
        [TestCase(true, null,null,null,null,null)]
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

            var result = await client.GetMarketEstimatedInfosAsync(request);
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

            var result = client.GetMarketEstimatedInfos(request);
            Assert.NotNull(result);

        }
    }
}