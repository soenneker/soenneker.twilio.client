using System;
using System.Threading;

namespace Soenneker.Twilio.Client.Abstract;

/// <summary>
/// A thread-safe global initialization utility for the Twilio client
/// </summary>
public interface ITwilioClientUtil : IDisposable
{
    void Init(CancellationToken cancellationToken = default);
}
