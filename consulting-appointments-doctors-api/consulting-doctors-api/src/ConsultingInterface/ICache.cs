using Presenters;

namespace ConsultingInterface;

public interface ICache
{
    Task<List<UserDto>> GetCacheAsync(string key);
    Task SaveCacheAsync(string key, List<UserDto> list);
}