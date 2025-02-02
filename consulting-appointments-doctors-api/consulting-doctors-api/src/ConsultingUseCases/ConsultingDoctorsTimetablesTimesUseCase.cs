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

    public ResultDto<List<DoctorsTimetablesTimesDto>> CreateDoctorsTimeTablesTimesDB(IEnumerable<DoctorsTimetablesTimesEntity> doctorsTimetablesTimesList, DoctorsTimetablesDateDto doctorsTimetablesDateDto, IEnumerable<AppointmentEntity> appointmentDbList)
    {
        var filteredList = doctorsTimetablesTimesList.Where(t => !appointmentDbList.Any(a => a.IdDoctorsTimetablesTime == t.Id && a.IdDoctorsTimetablesDate == doctorsTimetablesDateDto.Id)).ToList();

        var list = filteredList.Select(f => new DoctorsTimetablesTimesDto()
        {
            Id = f.Id.ToString(),
            Time = f.Time
        }).ToList();

        var result = new ResultDto<List<DoctorsTimetablesTimesDto>>
        {
            Data = list
        };

        return result;
    }
}
