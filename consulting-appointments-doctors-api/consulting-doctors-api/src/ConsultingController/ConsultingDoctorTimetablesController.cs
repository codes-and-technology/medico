using ConsultingInterface;
using ConsultingUseCase;
using Presenters;

namespace ConsultingController;
public class ConsultingDoctorTimetablesController(IDoctorsTimetablesDateDBGateway doctorsTimetablesDateDBGateway, IDoctorsTimetablesTimesDBGateway doctorsTimetablesTimesDBGateway) : IDoctorTimetablesController
{
    public async Task<ResultDto<List<DoctorsTimetablesDateDto>>> ConsultingTimetablesAsync(string idDoctor)
    {
        var useCase = new ConsultingDoctorsTimetablesDateUseCase();

        var doctorsTimetablesDateDBList = await doctorsTimetablesDateDBGateway.FindDoctorsTimetablesDateByIdDoctorAvailableAsync(idDoctor);

        var result = useCase.CreateDoctorsTimeTablesDateDB(doctorsTimetablesDateDBList);

        if (result.Data.Any())
        {
            foreach (var doctorsTimetablesDateDto in result.Data)
            {
                var doctorsTimetablesTimesDBList = await doctorsTimetablesTimesDBGateway.FindAsync(t => t.IdDoctorsTimetablesDate == doctorsTimetablesDateDto.Id && !t.DeleteDate.HasValue);

                if (doctorsTimetablesTimesDBList.Any())
                {
                    var useCaseTimes = new ConsultingDoctorsTimetablesTimesUseCase();
                    var doctorsTimetablesTimesDtoList = useCaseTimes.CreateDoctorsTimeTablesTimesDB(doctorsTimetablesTimesDBList);
                    
                    if(doctorsTimetablesTimesDtoList.Data.Any())
                        doctorsTimetablesDateDto.TimeList = doctorsTimetablesTimesDtoList.Data;
                }
            }
        }

        return result;
    }
}