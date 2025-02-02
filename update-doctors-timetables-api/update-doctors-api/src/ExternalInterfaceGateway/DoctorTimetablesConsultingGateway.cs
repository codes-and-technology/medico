using System.Text.Json;
using System.Text.Json.Serialization;
using UpdateEntitys;
using UpdateInterface;
using External.Interfaces;
using Newtonsoft.Json;
using Presenters;

namespace ExternalInterfaceGateway;

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