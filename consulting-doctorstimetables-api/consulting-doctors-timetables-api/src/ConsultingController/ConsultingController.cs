using ConsultingInterface;
using ConsultingUseCase;
using Presenters;

namespace ConsultingController;
public class ConsultingController(IDoctorsTimetablesDateDBGateway doctorsTimetablesDateDBGateway, IDoctorsTimetablesTimesDBGateway doctorsTimetablesTimesDBGateway, ICache<DoctorsTimetablesDateDto> cacheGateway) : IController
{
    public async Task<ResultDto<List<DoctorsTimetablesDateDto>>> ConsultingDoctorsTimetablesDateAsync(string idDoctor)
    {
        var cacheList = await cacheGateway.GetCacheAsync("DoctorsTimetablesDate");

        var useCase = new ConsultingDoctorsTimetablesDateUseCase();

        if (cacheList.Any())
        {
            var resultList = cacheList.Where(f => f.IdDoctor == idDoctor).ToList();

            if (resultList.Any())
                return useCase.CreateConsultingFromCache(cacheList);
        }

        var doctorsTimetablesDateDBList = await doctorsTimetablesDateDBGateway.FindDoctorsTimetablesDateByIdDoctorAsync(idDoctor);

        var result = useCase.CreateDoctorsTimeTablesDateDB(doctorsTimetablesDateDBList);

        if (result.Data.Any())
        {
            foreach (var doctorsTimetablesDateDto in result.Data)
            {
                var doctorsTimetablesTimesDBList = await doctorsTimetablesTimesDBGateway.FindAsync(t => t.IdDoctorsTimetablesDate == doctorsTimetablesDateDto.Id);

                if (doctorsTimetablesTimesDBList.Any())
                {
                    var useCaseTimes = new ConsultingDoctorsTimetablesTimesUseCase();
                    var doctorsTimetablesTimesDtoList = useCaseTimes.CreateDoctorsTimeTablesTimesDB(doctorsTimetablesTimesDBList);
                    
                    if(doctorsTimetablesTimesDtoList.Data.Any())
                        doctorsTimetablesDateDto.TimeList = doctorsTimetablesTimesDtoList.Data;
                }
            }

            await cacheGateway.SaveCacheAsync("DoctorsTimetablesDate", result.Data);
        }

        return result;
    }
}