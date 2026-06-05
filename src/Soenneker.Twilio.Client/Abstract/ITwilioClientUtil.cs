using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Twilio.Client.Abstract;

/// <summary>
/// A thread-safe global initialization utility for the Twilio client
/// </summary>
public interface ITwilioClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Synchronously initializes the instance.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    void InitSync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Initializes the instance.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    ValueTask Init(CancellationToken cancellationToken = default);
}
