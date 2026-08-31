using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Twilio.Client.Abstract;

/// <summary>
/// Initializes Twilio's process-wide SDK client from configuration.
/// </summary>
public interface ITwilioClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Synchronously initializes Twilio's process-wide SDK client once.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    void InitSync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Initializes Twilio's process-wide SDK client once.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    ValueTask Init(CancellationToken cancellationToken = default);
}
