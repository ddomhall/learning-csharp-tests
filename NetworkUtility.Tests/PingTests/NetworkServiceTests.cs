using FluentAssertions;
using FluentAssertions.Extensions;
using System.Net.NetworkInformation;

public class NetworkServiceTests
{
    private readonly NetworkService _networkService;
    public NetworkServiceTests() => _networkService = new NetworkService();

    [Fact]
    public void NetworkService_SendPing_ReturnString() => _networkService.SendPing().Should().Be("Success: Ping Sent!");

    [Theory]
    [InlineData(1, 1, 2)]
    [InlineData(2, 2, 4)]
    public void NetworkService_PingTimeout_ReturnsInt(int a, int b, int expected) => _networkService.PingTimeout(a, b).Should().Be(expected);

    [Fact]
    public void NetworkService_LastPingDate_ReturnsDate()
    {
        var result = _networkService.LastPingDate();
        result.Should().BeAfter(1.January(2010));
        result.Should().BeBefore(1.January(2030));
    }

    [Fact]  
    public void NetworkService_GetPingOptions_ReturnsObject()
    {
        var expected = new PingOptions() { DontFragment = true, Ttl = 1, };
        var result = _networkService.GetPingOptions();
        result.Should().BeOfType<PingOptions>();
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]  
    public void NetworkService_MostRecentPings_ReturnsIEnumerable()
    {
        var expected = new PingOptions() { DontFragment = true, Ttl = 1, };
        var result = _networkService.MostRecentPings();
        result.Should().ContainEquivalentOf(expected);
    }
}
