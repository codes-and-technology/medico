using Presenters;

namespace AuthInterface;

public interface IController
{
    Task<ResultDto<string>> AuthAsync(LoginDoctorDto login);
    Task<ResultDto<string>> AuthAsync(LoginPatientDto login);
}