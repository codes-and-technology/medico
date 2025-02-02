using Presenters;

namespace DeleteInterface;

public interface IDoctorTimetablesConsultingGateway
{
    Task<ConsultingDoctorTimetablesDateDto> GetAllAsync(string token);
}