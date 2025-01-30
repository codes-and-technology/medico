using ConsultingEntitys;
using Presenters;

namespace ConsultingInterface;

public interface IController
{
    Task<ResultDto<List<UserDto>>> ConsultingDoctorAsync();
}