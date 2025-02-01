namespace ConsultingInterface;

public interface ICache<T>
{
    Task<List<T>> GetCacheAsync(string key);
    Task SaveCacheAsync(string key, List<T> list);
}