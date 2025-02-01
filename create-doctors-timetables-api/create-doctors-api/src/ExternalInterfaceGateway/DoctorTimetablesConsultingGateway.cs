using CreateEntitys;
using CreateInterface;
using External.Interfaces;
using Presenters;

namespace ExternalInterfaceGateway;

public class DoctorTimetablesConsultingGateway(IDoctorTimetablesExternal doctorTimetablesApi)
    : IDoctorTimetablesConsultingGateway
{
    public async Task<IEnumerable<ConsultingDoctorTimetablesDateDto>> GetAllAsync(string token)
    {
        var result = await doctorTimetablesApi.Get(token);

        if (!result.IsSuccessStatusCode)
            throw new Exception("Falha ao tentar consultar horários");

        return result.Content;
    }
}