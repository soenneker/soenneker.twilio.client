using Soenneker.Twilio.Client.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;


namespace Soenneker.Twilio.Client.Tests;

[Collection("Collection")]
public class TwilioClientUtilTests : FixturedUnitTest
{
    private readonly ITwilioClientUtil _util;

    public TwilioClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<ITwilioClientUtil>(true);
    }
}
