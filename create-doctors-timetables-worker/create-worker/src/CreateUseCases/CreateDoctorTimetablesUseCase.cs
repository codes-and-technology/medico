using CreateEntitys;
using CreateInterface.UseCase;
using Presenters;

namespace CreateUseCases.UseCase;

public class CreateDoctorTimetablesUseCase : ICreateDoctorTimetablesUseCase
{
    public CreateResult<DoctorTimetablesDateEntity> Create(DoctorTimetablesDateEntity doctorTimetables)
    {
        var result = new CreateResult<DoctorTimetablesDateEntity>();

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