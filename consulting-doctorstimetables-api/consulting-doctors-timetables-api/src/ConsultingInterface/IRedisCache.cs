namespace ConsultingInterface;

public interface IRedisCache<T>
{
    Task<List<T>> GetCacheAsync(string key);
    Task SaveCacheAsync(string key, List<T> list);
}