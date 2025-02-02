using DeleteEntitys;
using DeleteInterface.UseCase;
using Presenters;

namespace DeleteUseCases.UseCase;

public class DeleteDoctorTimetablesUseCase : IDeleteDoctorTimetablesUseCase
{
    public DeleteResult<DoctorTimetablesDateEntity> DeleteFullList(DoctorTimetablesDateEntity doctorTimetables, List<DoctorTimetablesTimeEntity> dbList, DoctorTimetablesDateEntity doctorTimetablesDateEntity)
    {
        var result = new DeleteResult<DoctorTimetablesDateEntity>();
        
        if (doctorTimetablesDateEntity is null || dbList.All(a => a.IdDoctorsTimetablesDate != doctorTimetables.Id))
        {
            result.Errors.Add("A lista de horários não pertence ao médico");
            return result;
        }

        doctorTimetables.DoctorTimetablesTimes = dbList;
        result.Data = doctorTimetables;
        
        return result;
    }
    
    
    public DeleteResult<DoctorTimetablesDateEntity> Delete(DoctorTimetablesDateEntity doctorTimetables, List<DoctorTimetablesTimeEntity> dbList, List<DoctorTimetablesDateEntity> doctorTimetablesDateEntityList)
    {
        var result = new DeleteResult<DoctorTimetablesDateEntity>
        {
            Data = new DoctorTimetablesDateEntity
            {
                DoctorTimetablesTimes = []
            }
        };
        
        foreach (var item in doctorTimetablesDateEntityList)
        {
            if (item is null)
            {
                result.Errors.Add("Horário não pertence ao médico");
                break;
            }
        }
        
        if (result.Errors.Any())
        {
            return result;
        }
        
        foreach (var item in doctorTimetables.DoctorTimetablesTimes.Where(item => dbList.Any(x => x.Id == item.Id)))
        {
            result.Data.DoctorTimetablesTimes.Add(item);
        }
        
        doctorTimetables.DoctorTimetablesTimes = dbList;
        result.Data = doctorTimetables;
        
        return result;
    }
}