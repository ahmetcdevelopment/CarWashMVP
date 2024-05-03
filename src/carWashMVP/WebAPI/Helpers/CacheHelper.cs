using StackExchange.Redis;

namespace WebAPI.Helpers;

public static class CacheHelper
{
    public static bool CheckRedisAvailability(string conn)
    {
        try
        {
            ConnectionMultiplexer.ConnectAsync(conn).GetAwaiter().GetResult();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
