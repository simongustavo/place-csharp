# Place .NET Library

A .NET Library for interfacing with the Place API

## Installation

To manually install `place-csharp`, you can [download the source](https://github.com/placepay/place-csharp/zipball/master):

## Requirements

- [Json.Net](https://www.newtonsoft.com/json)

## Basic usage

```csharp
// set your api key
PlaceClient.api_key = 'private_key_6fsMi3GDxXg1XXSluNx1sLEd'

// create an account
PlaceAccount accnt = PlaceAccount.create(new {
	email="joe.schmoe@example.com",
	full_name="Joe Schmoe",
	user_type="payer"
});
```

## Documentation
Read the [docs](https://developer.placepay.com/?csharp)
