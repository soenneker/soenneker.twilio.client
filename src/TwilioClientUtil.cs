using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Soenneker.Extensions.Configuration;
using Soenneker.Twilio.Client.Abstract;
using Soenneker.Utils.AsyncSingleton;
using System.Threading;
using System;
using System.Threading.Tasks;
using Twilio;

namespace Soenneker.Twilio.Client;

/// <inheritdoc cref="ITwilioClientUtil"/>
public sealed class TwilioClientUtil : ITwilioClientUtil
{
    private readonly AsyncSingleton _client;

    public TwilioClientUtil(IConfiguration configuration, ILogger<TwilioClientUtil> logger)
    {
        _client = new AsyncSingleton((_, _) =>
        {
            logger.LogDebug("Initializing Twilio client...");

            var accountSid = configuration.GetValueStrict<string>("Twilio:AccountSid");
            var authToken = configuration.GetValueStrict<string>("Twilio:AuthToken");

            TwilioClient.Init(accountSid, authToken);

            return new object();
        });
    }

    public void InitSync(CancellationToken cancellationToken = default)
    {
        _client.InitSync(cancellationToken);
    }

    public ValueTask Init(CancellationToken cancellationToken = default)
    {
        return _client.Init(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}