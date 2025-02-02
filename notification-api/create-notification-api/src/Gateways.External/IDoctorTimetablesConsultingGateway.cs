using Presenters;

namespace Gateways.External;

public interface IDoctorTimetablesConsultingGateway
{
    Task<ConsultingDoctorTimetablesDateDto> GetAllAsync(string token);
}