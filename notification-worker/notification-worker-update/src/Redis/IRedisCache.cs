﻿namespace Redis
{
    public interface IRedisCache<T>
    {
        Task<List<T>> GetCacheAsync(string key);
        Task SaveCacheAsync(string key, List<T> list);
        Task ClearCacheAsync(string key);
    }
}
