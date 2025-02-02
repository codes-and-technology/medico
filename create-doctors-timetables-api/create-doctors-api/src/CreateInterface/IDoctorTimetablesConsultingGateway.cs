using Presenters;

namespace CreateInterface;

public interface IDoctorTimetablesConsultingGateway
{
    Task<ConsultingDoctorTimetablesDateDto> GetAllAsync(string token);
}