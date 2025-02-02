using UpdateEntitys;
using Presenters;

namespace UpdateUseCases;

public class UpdateUseCase(UpdateDoctorTimetablesDto updateDoctorTimetablesDto, 
    ConsultingDoctorTimetablesDateDto doctoTimetables,
    string doctorId)
{
    public ResultDto<List<DoctorTimetablesTimeEntity>> UpdateDoctorTimetablesTime()
    {
        var result = new ResultDto<List<DoctorTimetablesTimeEntity>>
        {
            Data = []
        };

        foreach (var item in updateDoctorTimetablesDto.TimeList)
        {
            if (doctoTimetables.Id != item.Id)
            {
                result.Errors.Add("ID da Data Disponível não encontrado");
            }

            if (!doctoTimetables.TimeList.Exists(a => a.Id == item.Id && a.IdDoctorsTimetablesDate == item.IdDoctorsTimetablesDate))
                result.Errors.Add("ID do Horário não encontrado");
                
            if (doctoTimetables.TimeList.Any(a => a.Time == item.Time && a.IdDoctorsTimetablesDate == item.IdDoctorsTimetablesDate))
                result.Errors.Add("Horário já cadastrado");
        }

        if (result.Errors.Any())
            return result;

        foreach (var item in updateDoctorTimetablesDto.TimeList)
        {
            result.Data.Add(new DoctorTimetablesTimeEntity()
            {
                Id = item.Id,
                IdDoctorTimeTablesDate = doctorId,
                Time = item.Time,
            });
        }
        
        return result;
    }

    public ResultDto<DoctorTimetablesDateEntity> UpdateEntity(string doctorId, string id, List<DoctorTimetablesTimeEntity> doctorTimetablesTimeList)
    {
        var result = new ResultDto<DoctorTimetablesDateEntity>
        {
            Data = new DoctorTimetablesDateEntity
            {
                DoctorTimetablesTimes = [.. doctorTimetablesTimeList],
                IdDoctor = doctorId,
                Id = id,
            }
        };

        return result;
    }
}
