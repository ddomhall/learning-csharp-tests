using System.Net.NetworkInformation;

public class NetworkService
{
    public string SendPing() => "Success: Ping Sent!";

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
