using NetworkUtility.DNS;
using System.Net.NetworkInformation;

public class NetworkService
{
    private readonly IDNS _dns;

    public NetworkService(IDNS dns)
    {
        _dns = dns;
    }
    public string SendPing() => _dns.SendDNS() ? "Success: Ping Sent!" : "Failed: Ping not sent!";

    public int PingTimeout(int a, int b) => a + b;

    public DateTime LastPingDate() => DateTime.Now;

    public PingOptions GetPingOptions()
    {
        return new PingOptions()
        {
            DontFragment = true,
            Ttl = 1,
        };
    }

    public IEnumerable<PingOptions> MostRecentPings()
    {
        return new[]
        {
            new PingOptions() { DontFragment = true, Ttl = 1, },
            new PingOptions() { DontFragment = false, Ttl = 2, },
            new PingOptions() { DontFragment = true, Ttl = 3, },
        };
    }
}
