using Presenters;

namespace AuthInterface;

public interface IController
{
    Task<ResultDto<string>> AuthAsync(LoginDto login);
}