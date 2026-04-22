using Soenneker.Twilio.Client.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Twilio.Client.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class TwilioClientUtilTests : HostedUnitTest
{
    private readonly ITwilioClientUtil _util;

    public TwilioClientUtilTests(Host host) : base(host)
    {
        _util = Resolve<ITwilioClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
