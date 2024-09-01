using FluentAssertions;
using System;

public class NetworkServiceTests
{
    [Fact]
    public void NetworkService_SendPing_ReturnString()
    {
        var pingService = new NetworkService();
        var result = pingService.SendPing();
        result.Should().Be("Success: Ping Sent!");
    }

    [Theory]
    [InlineData(1, 1, 2)]
    [InlineData(2, 2, 4)]
    public void NetworkService_PingTimeout_ReturnsInt(int a, int b, int expected)
    {
        var pingService = new NetworkService();
        var result = pingService.PingTimeout(a, b);
        result.Should().Be(expected);
    }
}
