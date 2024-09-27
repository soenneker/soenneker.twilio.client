using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Soenneker.Extensions.Configuration;
using Soenneker.Twilio.Client.Abstract;
using Soenneker.Utils.AsyncSingleton;
using System.Threading;
using System;
using Twilio;

namespace Soenneker.Twilio.Client;

/// <inheritdoc cref="ITwilioClientUtil"/>
public class TwilioClientUtil: ITwilioClientUtil
{
    private readonly AsyncSingleton<object> _client;

    public TwilioClientUtil(IConfiguration configuration, ILogger<TwilioClientUtil> logger)
    {
        _client = new AsyncSingleton<object>((_, _) =>
        {
            logger.LogDebug("Initializing Twilio client...");

            var accountSid = configuration.GetValueStrict<string>("Twilio:AccountSid");
            var authToken = configuration.GetValueStrict<string>("Twilio:AuthToken");

            TwilioClient.Init(accountSid, authToken);

            return new object();
        });
    }

    public void Init(CancellationToken cancellationToken = default)
    {
        _client.GetSync(cancellationToken);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        _client.Dispose();
    }
}
