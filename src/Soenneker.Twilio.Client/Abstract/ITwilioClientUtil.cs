using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Twilio.Client.Abstract;

/// <summary>
/// A thread-safe global initialization utility for the Twilio client
/// </summary>
public interface ITwilioClientUtil : IDisposable, IAsyncDisposable
{
    void InitSync(CancellationToken cancellationToken = default);

    ValueTask Init(CancellationToken cancellationToken = default);
}
