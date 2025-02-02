using Presenters;

namespace CreateInterface;

public interface IDoctorTimetablesConsultingGateway
{
    Task<List<ConsultingDoctorTimetablesDateDto>> GetAllAsync(string token);
}