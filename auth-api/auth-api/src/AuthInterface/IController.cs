using Presenters;

namespace CreateInterface;

public interface IController
{
    Task<ResultDto<string>> AuthAsync(LoginDto login);
}