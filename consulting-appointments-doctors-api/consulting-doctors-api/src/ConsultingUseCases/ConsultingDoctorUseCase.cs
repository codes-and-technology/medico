using ConsultingEntitys;
using Presenters;

namespace ConsultingUseCases;

public class ConsultingDoctorUseCase()
{
    public ResultDto<List<UserDto>> CreateConsultingFromCache(List<UserDto> doctorList)
    {
        var result = new ResultDto<List<UserDto>>
        {
            Data = doctorList
        };
        
        return result;
    }
    
    public ResultDto<List<UserDto>> CreateConsultingFromDb(IEnumerable<UserEntity> doctorList)
    {
        var list = doctorList.Select(f => new UserDto()
        {
            Id = f.Id.ToString(),
            Email = f.Email,
            Name = f.Name,
            CRM = f.CRM
        }).ToList();
        
        var result = new ResultDto<List<UserDto>>
        {
            Data = list
        };

        return result;
    }
}
