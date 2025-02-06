using Entitys;
using Presenters;

namespace UseCases;

public class AppointmentUseCase()
{
    public ResultDto<CreatedAppointmentDto> CreateAppointment(string idPatient, CreateAppointmentDto dto, IEnumerable<AppointmentEntity> appointmentDbList)
    {
        var result = new ResultDto<CreatedAppointmentDto>();

        if(idPatient is null)
            result.Errors.Add("ID do paciente deve ser informado");

        if (appointmentDbList.ToList().Exists(a => a.IdPatient == idPatient && a.IdDoctor == dto.IdDoctor && a.IdDoctorsTimetablesDate == dto.IdDoctorsTimetablesDate && a.IdDoctorsTimetablesTime == dto.IdDoctorsTimetablesTime && !a.DeleteDate.HasValue))
            result.Errors.Add("Agendamento já existe");

        return result;
    }
    
    public ResultDto<string> CreateConfirm(AppointmentEntity appointmentDb, bool isConfirmed)
    {
        var result = new ResultDto<string>();

        if(appointmentDb is null)
            result.Errors.Add("Agendamento não localizado");

        result.Data = appointmentDb.Id;
        appointmentDb.Status = isConfirmed ? "CONFIRMED" : "CANCELED";

        return result;
    }
}
