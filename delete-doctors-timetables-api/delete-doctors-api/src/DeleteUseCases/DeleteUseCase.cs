using DeleteEntitys;
using Presenters;

namespace DeleteUseCases;

public class DeleteUseCase(DeleteDoctorTimetablesDto deleteDoctorTimetablesDto)
{
    public ResultDto<List<DoctorTimetablesTimeEntity>> DeleteDoctorTimetablesTime()
    {
        var result = new ResultDto<List<DoctorTimetablesTimeEntity>>
        {
            Data = []
        };

        if (string.IsNullOrEmpty(deleteDoctorTimetablesDto.Id) && deleteDoctorTimetablesDto.TimeList is not null && deleteDoctorTimetablesDto.TimeList.Count == 0)
        {
            result.Errors.Add("Id da Data ou lita de horários não encontrado");
            return result;
        }

        if (deleteDoctorTimetablesDto.TimeList is null || deleteDoctorTimetablesDto.TimeList.Count == 0) 
            return result;
        
        foreach (var item in deleteDoctorTimetablesDto.TimeList)
        {
            result.Data.Add(new DoctorTimetablesTimeEntity()
            {
                Id = item.Id,
                IdDoctorsTimetablesDate = deleteDoctorTimetablesDto.Id,
            });
        }
        
        return result;
    }

    public ResultDto<DoctorTimetablesDateEntity> DeleteEntity(string doctorId, string id, List<DoctorTimetablesTimeEntity> doctorTimetablesTimeList)
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
