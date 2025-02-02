using Presenters;

namespace UpdateInterface;

public interface IDoctorTimetablesConsultingGateway
{
    Task<ConsultingDoctorTimetablesDateDto> GetAllAsync(string token);
}