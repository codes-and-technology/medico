using UpdateEntitys;
using UpdateInterface.UseCase;
using Presenters;

namespace UpdateUseCases.UseCase;

public class UpdateDoctorTimetablesUseCase : IUpdateDoctorTimetablesUseCase
{
    public UpdateResult<DoctorTimetablesDateEntity> Update(DoctorTimetablesDateEntity doctorTimetables)
    {
        var result = new UpdateResult<DoctorTimetablesDateEntity>();

        if (doctorTimetables is null)
        {
            result.Errors.Add("Objeto vazio");
        }

        if (string.IsNullOrEmpty(doctorTimetables.IdDoctor))
        {
            result.Errors.Add("IdDoctor vazio");
        }

        if (!doctorTimetables.DoctorTimetablesTimes.Any())
        {
            result.Errors.Add("Doctor timetables vazio");
        }
        result.Data = doctorTimetables;
        
        result.Valid(doctorTimetables);

        return result;
    }
}