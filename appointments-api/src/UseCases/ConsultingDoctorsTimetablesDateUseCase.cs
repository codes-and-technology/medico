using Entitys;
using Presenters;

namespace UseCases;

public class ConsultingDoctorsTimetablesDateUseCase()
{
    public ResultDto<List<DoctorsTimetablesDateDto>> CreateConsultingFromCache(List<DoctorsTimetablesDateDto> list)
    {
        var result = new ResultDto<List<DoctorsTimetablesDateDto>>
        {
            Data = list
        };
        
        return result;
    }
    
    public ResultDto<List<DoctorsTimetablesDateDto>> CreateDoctorsTimeTablesDateDB(IEnumerable<DoctorsTimetablesDateEntity> doctorsTimetablesDateList)
    {
        var list = doctorsTimetablesDateList.Select(f => new DoctorsTimetablesDateDto()
        {
            Id = f.Id.ToString(),
            IdDoctor = f.IdDoctor,
            Date = f.AvailableDate.ToString("yyyy-MM-dd")
        }).ToList();

        var result = new ResultDto<List<DoctorsTimetablesDateDto>>
        {
            Data = list
        };

        return result;
    }
}
