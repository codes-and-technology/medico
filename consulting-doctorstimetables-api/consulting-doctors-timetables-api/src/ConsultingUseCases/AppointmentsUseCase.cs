using ConsultingEntitys;
using Presenters;

namespace ConsultingUseCase;

public class AppointmentsUseCase()
{
    public ResultDto<List<AppointmentsDto>> CreateConsultingFromCache(List<AppointmentsDto> doctorList)
    {
        var result = new ResultDto<List<AppointmentsDto>>
        {
            Data = doctorList
        };
        
        return result;
    }
    
    public ResultDto<List<AppointmentsDto>> CreateUsersDB(IEnumerable<AppointmentsEntity> doctorList)
    {
        var list = doctorList.Select(f => new AppointmentsDto()
        {
            Id = f.Id.ToString(),
            IdDoctor = f.IdDoctor,
            IdDoctorsTimetablesDate = f.IdDoctorsTimetablesDate,
            IdDoctorsTimetablesTime = f.IdDoctorsTimetablesTime
        }).ToList();
        
        var result = new ResultDto<List<AppointmentsDto>>
        {
            Data = list
        };

        return result;
    }
}
