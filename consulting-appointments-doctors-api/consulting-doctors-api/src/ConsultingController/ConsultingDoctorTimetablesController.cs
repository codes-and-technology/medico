using ConsultingInterface;
using ConsultingUseCase;
using Presenters;

namespace ConsultingController;
public class ConsultingDoctorTimetablesController(IDoctorsTimetablesDateDBGateway doctorsTimetablesDateDBGateway, IDoctorsTimetablesTimesDBGateway doctorsTimetablesTimesDBGateway, IAppointmentDBGateway appointmentDBGateway) : IDoctorTimetablesController
{
    public async Task<ResultDto<List<DoctorsTimetablesDateDto>>> ConsultingTimetablesAsync(string idDoctor)
    {
        var useCase = new ConsultingDoctorsTimetablesDateUseCase();

        var doctorsTimetablesDateDBList = await doctorsTimetablesDateDBGateway.FindAllAsync(d => d.IdDoctor == idDoctor && d.AvailableDate.Date >= DateTime.Now.Date && !d.DeleteDate.HasValue);
        var result = useCase.CreateDoctorsTimeTablesDateDB(doctorsTimetablesDateDBList);

        if (result.Data.Any())
        {
            var appointmentDbList = await appointmentDBGateway.FindAllAsync(a => a.IdDoctor == idDoctor);
            foreach (var doctorsTimetablesDateDto in result.Data)
            {
                var doctorsTimetablesTimesDBList = await doctorsTimetablesTimesDBGateway.FindAsync(t => t.IdDoctorsTimetablesDate == doctorsTimetablesDateDto.Id && !t.DeleteDate.HasValue);

                if (doctorsTimetablesTimesDBList.Any())
                {
                    var useCaseTimes = new ConsultingDoctorsTimetablesTimesUseCase();
                    var doctorsTimetablesTimesDtoList = useCaseTimes.CreateDoctorsTimeTablesTimesDB(doctorsTimetablesTimesDBList, doctorsTimetablesDateDto, appointmentDbList);
                    
                    if(doctorsTimetablesTimesDtoList.Data.Any())
                        doctorsTimetablesDateDto.TimeList = doctorsTimetablesTimesDtoList.Data;
                }
            }
        }

        result.Data = result.Data.Where(d => d.TimeList != null && d.TimeList.Any()).ToList();
        return result;
    }
}