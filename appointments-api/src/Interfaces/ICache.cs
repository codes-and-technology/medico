using Presenters;

namespace Interfaces;

public interface ICache
{
    Task<List<UserDto>> GetCacheAsync(string key);
    Task SaveCacheAsync(string key, List<UserDto> list);
}