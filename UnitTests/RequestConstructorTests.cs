using ChangeNowApi_V2.Consts;
using ChangeNowApi_V2.Dto;
using ChangeNowApi_V2.Enums;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    class RequestConstructorTests
    {
        [Test]
        public void CurrencyRequestConstruktor()
        {
            var obj = new CurrencyRequest();

            Assert.False(obj.Active);
            Assert.False(obj.Active);
            Assert.False(obj.Active);
            CurrencyRequestConstruktorTestCommonAssert(obj);

            obj = new CurrencyRequest(true);

            Assert.True(obj.Active);
            Assert.False(obj.Buy);
            Assert.False(obj.Sell);
            Assert.AreEqual(obj.Flow, FlowEnum.Standard);
            CurrencyRequestConstruktorTestCommonAssert(obj);

            obj = new CurrencyRequest(false, true);

            Assert.False(obj.Active);
            Assert.True(obj.Buy);
            Assert.False(obj.Sell);
            Assert.AreEqual(obj.Flow, FlowEnum.Standard);
            CurrencyRequestConstruktorTestCommonAssert(obj);

            obj = new CurrencyRequest(false, false, true);

            Assert.False(obj.Active);
            Assert.False(obj.Buy);
            Assert.True(obj.Sell);
            Assert.AreEqual(obj.Flow, FlowEnum.Standard);
            CurrencyRequestConstruktorTestCommonAssert(obj);

            obj = new CurrencyRequest(false, false, false, FlowEnum.FixedRate);

            Assert.False(obj.Active);
            Assert.False(obj.Buy);
            Assert.False(obj.Sell);
            Assert.AreEqual(obj.Flow, FlowEnum.FixedRate);
            CurrencyRequestConstruktorTestCommonAssert(obj);
        }

        [Test]
        public void MinimalExchangeRequestConstruktor()
        {
            var obj = new MinimalExchangeRequest("btc","eth",FlowEnum.FixedRate,"btc","eth");

            Assert.AreEqual("btc", obj.FromCurrency);
            Assert.AreEqual("eth", obj.ToCurrency);
            Assert.AreEqual(FlowEnum.FixedRate, obj.Flow);
            Assert.AreEqual("btc", obj.FromNetwork);
            Assert.AreEqual("eth", obj.ToNetwork);
            MinimalExchangeRequestConstruktorTestCommonAssert(obj);

            obj = new MinimalExchangeRequest("btc", "eth");

            Assert.AreEqual("btc", obj.FromCurrency);
            Assert.AreEqual("eth", obj.ToCurrency);
            Assert.AreEqual(FlowEnum.Standard, obj.Flow);
            Assert.AreEqual(string.Empty, obj.FromNetwork);
            Assert.AreEqual(string.Empty, obj.ToNetwork);
            MinimalExchangeRequestConstruktorTestCommonAssert(obj);

        }

        [Test]
        public void ExchangeRangeRequestConstruktor()
        {
            var obj = new ExchangeRangeRequest("btc", "eth", FlowEnum.FixedRate, "btc", "eth");

            Assert.AreEqual("btc", obj.FromCurrency);
            Assert.AreEqual("eth", obj.ToCurrency);
            Assert.AreEqual(FlowEnum.FixedRate, obj.Flow);
            Assert.AreEqual("btc", obj.FromNetwork);
            Assert.AreEqual("eth", obj.ToNetwork);
            ExchangeRangeRequestConstruktorTestCommonAssert(obj);

            obj = new ExchangeRangeRequest("btc", "eth");

            Assert.AreEqual("btc", obj.FromCurrency);
            Assert.AreEqual("eth", obj.ToCurrency);
            Assert.AreEqual(FlowEnum.Standard, obj.Flow);
            Assert.AreEqual(string.Empty, obj.FromNetwork);
            Assert.AreEqual(string.Empty, obj.ToNetwork);
            ExchangeRangeRequestConstruktorTestCommonAssert(obj);

        }

        [Test]
        public void EstimatedExchangeAmountRequestConstruktor()
        {
            var obj = new EstimatedExchangeAmountRequest("btc", "eth",10, FlowEnum.FixedRate);

            Assert.AreEqual("btc", obj.FromCurrency);
            Assert.AreEqual("eth", obj.ToCurrency);
            Assert.AreEqual(10, obj.FromAmount);
            Assert.AreEqual(FlowEnum.FixedRate, obj.Flow);
            Assert.AreEqual(string.Empty, obj.FromNetwork);
            Assert.AreEqual(string.Empty, obj.ToNetwork);
            Assert.AreEqual(0, obj.ToAmount);
            Assert.AreEqual(DirectionEnum.Direct, obj.Type);
            Assert.AreEqual(false, obj.UseRateId);

            obj = new EstimatedExchangeAmountRequest("btc", "eth", 10, true, FlowEnum.FixedRate);

            Assert.AreEqual("btc", obj.FromCurrency);
            Assert.AreEqual("eth", obj.ToCurrency);
            Assert.AreEqual(10, obj.FromAmount);
            Assert.AreEqual(FlowEnum.FixedRate, obj.Flow);
            Assert.AreEqual(string.Empty, obj.FromNetwork);
            Assert.AreEqual(string.Empty, obj.ToNetwork);
            Assert.AreEqual(0, obj.ToAmount);
            Assert.AreEqual(DirectionEnum.Direct, obj.Type);
            Assert.AreEqual(true, obj.UseRateId);

            obj = new EstimatedExchangeAmountRequest("btc", "eth", 0, 10, FlowEnum.Standard,DirectionEnum.Reverse,false,"doge","grs");

            Assert.AreEqual("btc", obj.FromCurrency);
            Assert.AreEqual("eth", obj.ToCurrency);
            Assert.AreEqual(0, obj.FromAmount);
            Assert.AreEqual(FlowEnum.Standard, obj.Flow);
            Assert.AreEqual("doge", obj.FromNetwork);
            Assert.AreEqual("grs", obj.ToNetwork);
            Assert.AreEqual(10, obj.ToAmount);
            Assert.AreEqual(DirectionEnum.Reverse, obj.Type);
            Assert.AreEqual(false, obj.UseRateId);

        }

        [Test]
        public void TransactionStatusRequestConstruktor()
        {
            var obj = new TransactionStatusRequest("IdYouGetFromCreateExchangeTransaction");

            Assert.AreEqual("IdYouGetFromCreateExchangeTransaction", obj.Id);
 
        }

        [Test]
        public void AddressValidationRequestConstruktor()
        {
            var obj = new AddressValidationRequest("btc","address");

            Assert.AreEqual("btc", obj.Currency);
            Assert.AreEqual("address", obj.Address);
            Assert.True( obj.IsValidationAvailable);

            obj = new AddressValidationRequest("dash", "someAddress");
            Assert.False(obj.IsValidationAvailable);

            obj = new AddressValidationRequest("ltc", "someAddress");
            Assert.False(obj.IsValidationAvailable);

            obj = new AddressValidationRequest(CurrencyAddressValidationEnum.adx, "SomeAddress");
            Assert.AreEqual("adx", obj.Currency);
            Assert.AreEqual("SomeAddress", obj.Address);
            Assert.True(obj.IsValidationAvailable);

        }

        [Test]
        public void FioAddressesRequestConstruktor()
        {
            var obj = new FioAddressesRequest("name");

            Assert.AreEqual("name", obj.Name);
        }

        [Test]
        public void MarketEstimatedRequestConstruktor()
        {
            var obj = new MarketEstimatedRequest("btc","eth",1,0,DirectionEnum.Direct);

            Assert.AreEqual("btc", obj.FromCurrency);
            Assert.AreEqual("eth", obj.ToCurrency);
            Assert.AreEqual(1, obj.FromAmount);
            Assert.AreEqual(0, obj.ToAmount);
            Assert.AreEqual(DirectionEnum.Direct, obj.Type);
            Assert.AreEqual(Messages.ParameterNotUseForThisRequest, obj.FromNetwork);
            Assert.AreEqual(Messages.ParameterNotUseForThisRequest, obj.ToNetwork);
        }

        [Test]
        public void TransactionRequestConstruktor()
        {
            var obj = new TransactionRequest("btc", "eth", 1,"address",FlowEnum.FixedRate,DirectionEnum.Direct,0,"extraId","refundAddress","refundExtraId","userId","payLoad","email","rateId","btc","eth");

            Assert.AreEqual("btc", obj.FromCurrency);
            Assert.AreEqual("eth", obj.ToCurrency);
            Assert.AreEqual(1, obj.FromAmount);
            Assert.AreEqual("address", obj.Address);
            Assert.AreEqual(FlowEnum.FixedRate, obj.Flow);
            Assert.AreEqual(DirectionEnum.Direct, obj.Type);
            Assert.AreEqual("extraId", obj.ExtraId);
            Assert.AreEqual("refundAddress", obj.RefundAddress);
            Assert.AreEqual("refundExtraId", obj.RefundExtraId);
            Assert.AreEqual("userId", obj.UserId);
            Assert.AreEqual("payLoad", obj.PayLoad);
            Assert.AreEqual("email", obj.ConactEmail);
            Assert.AreEqual("rateId", obj.RateID);
            Assert.AreEqual("btc", obj.FromNetwork);
            Assert.AreEqual("eth", obj.ToNetwork);

           obj = new TransactionRequest("doge", "grs", 570, "grsAddress");

            Assert.AreEqual("doge", obj.FromCurrency);
            Assert.AreEqual("grs", obj.ToCurrency);
            Assert.AreEqual(570, obj.FromAmount);
            Assert.AreEqual("grsAddress", obj.Address);
            Assert.AreEqual(FlowEnum.Standard, obj.Flow);
            Assert.AreEqual(DirectionEnum.Direct, obj.Type);
            Assert.AreEqual(string.Empty, obj.ExtraId);
            Assert.AreEqual(string.Empty, obj.RefundAddress);
            Assert.AreEqual(string.Empty, obj.RefundExtraId);
            Assert.AreEqual(string.Empty, obj.UserId);
            Assert.AreEqual(string.Empty, obj.PayLoad);
            Assert.AreEqual(string.Empty, obj.ConactEmail);
            Assert.AreEqual(string.Empty, obj.RateID);
            Assert.AreEqual(string.Empty, obj.FromNetwork);
            Assert.AreEqual(string.Empty, obj.ToNetwork);

            obj = new TransactionRequest("doge", "grs", 570, "grsAddress",FlowEnum.FixedRate);

            Assert.AreEqual("doge", obj.FromCurrency);
            Assert.AreEqual("grs", obj.ToCurrency);
            Assert.AreEqual(570, obj.FromAmount);
            Assert.AreEqual("grsAddress", obj.Address);
            Assert.AreEqual(FlowEnum.FixedRate, obj.Flow);
            Assert.AreEqual(DirectionEnum.Direct, obj.Type);
            Assert.AreEqual(string.Empty, obj.ExtraId);
            Assert.AreEqual(string.Empty, obj.RefundAddress);
            Assert.AreEqual(string.Empty, obj.RefundExtraId);
            Assert.AreEqual(string.Empty, obj.UserId);
            Assert.AreEqual(string.Empty, obj.PayLoad);
            Assert.AreEqual(string.Empty, obj.ConactEmail);
            Assert.AreEqual(string.Empty, obj.RateID);
            Assert.AreEqual(string.Empty, obj.FromNetwork);
            Assert.AreEqual(string.Empty, obj.ToNetwork);


        }


        #region //---- private helper functions ----

        private void CurrencyRequestConstruktorTestCommonAssert(CurrencyRequest obj)
        {
            Assert.AreEqual(obj.FromCurrency, Messages.ParameterNotUseForThisRequest);
            Assert.AreEqual(obj.ToCurrency, Messages.ParameterNotUseForThisRequest);
            Assert.AreEqual(obj.FromAmount, 0);
            Assert.AreEqual(obj.ToAmount, 0);
            Assert.AreEqual(obj.FromNetwork, Messages.ParameterNotUseForThisRequest);
            Assert.AreEqual(obj.ToNetwork, Messages.ParameterNotUseForThisRequest);
            Assert.AreEqual(obj.Type, DirectionEnum.Direct);
        }

        private void MinimalExchangeRequestConstruktorTestCommonAssert(MinimalExchangeRequest obj)
        {
            Assert.AreEqual(0, obj.ToAmount);
            Assert.AreEqual(0, obj.FromAmount);
            Assert.AreEqual(DirectionEnum.Direct, obj.Type);
        }

        private void ExchangeRangeRequestConstruktorTestCommonAssert(ExchangeRangeRequest obj)
        {
            Assert.AreEqual(0, obj.ToAmount);
            Assert.AreEqual(0, obj.FromAmount);
            Assert.AreEqual(DirectionEnum.Direct, obj.Type);
        }

        #endregion
    }
}
