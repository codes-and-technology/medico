using ConsultingEntitys;
using Presenters;

namespace ConsultingUseCase;

public class ConsultingDoctorsTimetablesTimesUseCase()
{
    public ResultDto<List<DoctorsTimetablesTimesDto>> CreateConsultingFromCache(List<DoctorsTimetablesTimesDto> list)
    {
        var result = new ResultDto<List<DoctorsTimetablesTimesDto>>
        {
            Data = list
        };
        
        return result;
    }
    
    public ResultDto<List<DoctorsTimetablesTimesDto>> CreateDoctorsTimeTablesTimesDB(IEnumerable<DoctorsTimetablesTimesEntity> DoctorsTimetablesDateList)
    {
        var list = DoctorsTimetablesDateList.Select(f => new DoctorsTimetablesTimesDto()
        {
            Id = f.Id.ToString(),
            Time = f.Time,
            IdDoctorsTimetablesDate = f.IdDoctorsTimetablesDate           
        }).ToList();

        var result = new ResultDto<List<DoctorsTimetablesTimesDto>>
        {
            Data = list
        };

        return result;
    }
}
