# ChangeNowApi.NetCore 

.Net Core library for accessing the [ChangeNow V2 Api](https://changenow.io/api/docs) for C#/NET.

## Installation
Use the nuget package manager to install
```bash
Install-Package ChangeNowApi_V2 -Version 1.0.0
```

## Usage
For this API you need a [API KEY](https://changenow.io?link_id=e1c506d2e6ebc6) <br />

If you also want to use the <b>fixed-rate</b> feature, you have to contact support to get a special key.<br />

To see how this library is used, I recommend the Unittest Project. Every function is used.<br /><br/>

```c#
//get a client
var client = new ChangeNowClient("YOUR API KEY");

//get available currencies
var request = new CurrencyRequest() { Active = true};
var cur = client.GetListOfAvailableCurrencies(request);

//validate address
var request = new AddressValidationRequest(){ Curreny = "btc", Address = "31hA6mRWcGihPhiuChqerESdazQJgbbjeb"};
var isValid = client.ValidateAddress(request);

//create exchange
var request = new TransactionRequest(){ FromCurrency = "btc", ToCurrency = "eth", Address = "0x6E2876b9d7aa6b877d77643D962F0c3237Bf023f", FromAmount = "0.1" };
var response = client.CreateExchangeTransaction(request);
```
 All function also can call async




## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.


## License
[MIT](https://choosealicense.com/licenses/mit/)

## Buy me new socks
[BTC] 31hA6mRWcGihPhiuChqerESdazQJgbbjeb <br />
[ETH] 0x6E2876b9d7aa6b877d77643D962F0c3237Bf023f <br />
[LTC] MNFzK7SAXiRTzvQwjynsAioKectM42jev6<br />
[GRS] grs1qaspw4a89arun2vw2tceur8f542ceyw6wjn35nr <br />
[Doge] D9V1LUdQV8EakUjfHH9rAzFzLeNGWoqTXr <br />
[Dash] XfQtuiiLsiDnGFwKgLWXKJFtBh9EGMfKWH <br />


