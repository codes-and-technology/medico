using Presenters;

namespace ConsultingInterface;

public interface IDoctorController
{
    Task<ResultDto<List<UserDto>>> ConsultingDoctorAsync();
}