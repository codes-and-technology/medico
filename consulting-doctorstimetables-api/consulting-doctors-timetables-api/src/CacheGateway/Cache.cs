using ConsultingInterface;

namespace CacheGateway;

public class Cache<T>(IRedisCache<T> redis) : ICache<T>
{
    public async Task<List<T>> GetCacheAsync(string key) => await redis.GetCacheAsync(key);

    public async Task SaveCacheAsync(string key, List<T> list) => await redis.SaveCacheAsync(key,list);
}