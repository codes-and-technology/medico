using Presenters;

namespace CreateInterface;

public interface IDoctorTimetablesConsultingGateway
{
    Task<IEnumerable<ConsultingDoctorTimetablesDateDto>> GetAllAsync(string token);
}