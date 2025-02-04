using Presenters;

namespace Interfaces;

public interface IDoctorController
{
    Task<ResultDto<List<UserDto>>> ConsultingDoctorAsync();
}