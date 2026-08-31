[![](https://img.shields.io/nuget/v/soenneker.twilio.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.twilio.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.twilio.client/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.twilio.client/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.twilio.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.twilio.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.twilio.client/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.twilio.client/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Twilio.Client
Initializes Twilio's process-wide .NET SDK client from configuration.

## Installation

```bash
dotnet add package Soenneker.Twilio.Client
```

## Configuration

```json
{
  "Twilio": {
    "AccountSid": "AC...",
    "AuthToken": "your-auth-token"
  }
}
```

Keep the auth token in a secret provider or environment-specific configuration. Do not commit it or include it in logs.

## Registration

```csharp
using Soenneker.Twilio.Client.Registrars;

services.AddTwilioClientUtilAsSingleton();
```

Singleton registration matches Twilio's SDK design: `TwilioClient.Init` configures static, process-wide state. `AddTwilioClientUtilAsScoped()` is available for compatibility, but separate scopes do not isolate accounts or credentials.

## Usage

```csharp
using Soenneker.Twilio.Client.Abstract;
using Twilio.Rest.Api.V2010.Account;

await twilioClient.Init(cancellationToken);

CallResource? call = await CallResource.FetchAsync(pathSid: callSid);
```

Call `Init()` before using Twilio's static resource APIs. Repeated calls through the singleton are safe and return after the first initialization completes. Use `InitSync()` only from synchronous code that cannot await initialization.

This package is not a multi-account client factory. If one process must issue requests for several Twilio accounts concurrently, use explicit `ITwilioRestClient` instances rather than changing the global `TwilioClient` credentials.
