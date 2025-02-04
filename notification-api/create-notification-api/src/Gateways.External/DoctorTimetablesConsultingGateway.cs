using Entitys;
using External.Interfaces;
using Presenters;

namespace Gateways.External;

public class DoctorTimetablesConsultingGateway(IDoctorTimetablesExternal doctorTimetablesApi)
    : IDoctorTimetablesConsultingGateway
{
    public async Task<ConsultingDoctorTimetablesDateDto> GetAllAsync(string token)
    {
        var result = await doctorTimetablesApi.Get(token);

        if (!result.IsSuccessStatusCode)
            throw new Exception("Falha ao tentar consultar horários");

        return result.Content.Data.FirstOrDefault();
    }
}