using Entitys;
using Presenters;

namespace UseCases;

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
            CRM = f.CRM,
            Amount = f.Amount,
            PhysicianAssessment = f.PhysicianAssessment,
            Specialty = f.Specialty,
        }).ToList();
        
        var result = new ResultDto<List<UserDto>>
        {
            Data = list
        };

        return result;
    }
}
