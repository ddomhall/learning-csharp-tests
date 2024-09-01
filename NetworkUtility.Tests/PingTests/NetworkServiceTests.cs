using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.DNS;
using System.Net.NetworkInformation;

public class NetworkServiceTests
{
    private readonly NetworkService _pingService;
    private readonly IDNS _dns;
    public NetworkServiceTests()
    {
        _dns = A.Fake<IDNS> ();
        _pingService = new NetworkService(_dns);
    }

    [Fact]
    public void NetworkService_SendPing_ReturnString()
    {
        A.CallTo(() => _dns.SendDNS()).Returns(true);
        var result = _pingService.SendPing();
        result.Should().Be("Success: Ping Sent!");
    }

    [Theory]
    [InlineData(1, 1, 2)]
    [InlineData(2, 2, 4)]
    public void NetworkService_PingTimeout_ReturnsInt(int a, int b, int expected) => _pingService.PingTimeout(a, b).Should().Be(expected);

    [Fact]
    public void NetworkService_LastPingDate_ReturnsDate()
    {
        var result = _pingService.LastPingDate();
        result.Should().BeAfter(1.January(2010));
        result.Should().BeBefore(1.January(2030));
    }

    [Fact]  
    public void NetworkService_GetPingOptions_ReturnsObject()
    {
        var expected = new PingOptions() { DontFragment = true, Ttl = 1, };
        var result = _pingService.GetPingOptions();
        result.Should().BeOfType<PingOptions>();
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]  
    public void NetworkService_MostRecentPings_ReturnsIEnumerable()
    {
        var expected = new PingOptions() { DontFragment = true, Ttl = 1, };
        var result = _pingService.MostRecentPings();
        result.Should().ContainEquivalentOf(expected);
    }
}
