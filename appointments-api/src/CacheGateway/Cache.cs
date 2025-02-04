using Interfaces;
using Presenters;

namespace CacheGateway;

public class Cache(IRedisCache<UserDto> redis) : ICache
{
    public async Task<List<UserDto>> GetCacheAsync(string key) => await redis.GetCacheAsync(key);

    public async Task SaveCacheAsync(string key, List<UserDto> list) => await redis.SaveCacheAsync(key,list);
}