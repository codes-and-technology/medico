using CreateEntitys;
using Presenters;

namespace CreateUseCases;

public class CreateUseCase(CreateDoctorTimetablesDto createDoctorTimetablesDto, 
    List<ConsultingDoctorTimetablesDateDto> doctoTimetablesList,
    string doctorId)
{
    public ResultDto<DoctorTimetablesDateEntity> CreateDoctorTimetablesDate()
    {
        var result = new ResultDto<DoctorTimetablesDateEntity>();
       
        if (doctoTimetablesList is not null && doctoTimetablesList
                .Any(e => 
                    e.Date == createDoctorTimetablesDto.AvailableDate.ToString("dd/MM/yyyy") &&
                    e.TimeList.Any(item => 
                        createDoctorTimetablesDto.Times.Contains(item.Time))
                ))
        {
            result.Errors.Add("Existe Data e Horário cadastrado no sistema, verifique os dados e tente novamente.");
            return result;
        }
        
        result.Data = new DoctorTimetablesDateEntity()
        {
            Id = Guid.NewGuid().ToString(),
            CreateDate = DateTime.Now,
            IdDoctor = doctorId,
            AvailableDate = createDoctorTimetablesDto.AvailableDate
        };
        return result;
    }
    
    public ResultDto<List<DoctorTimetablesTimeEntity>> CreateDoctorTimetablesTime()
    {
        var result = new ResultDto<List<DoctorTimetablesTimeEntity>>
        {
            Data = []
        };

        foreach (var item in createDoctorTimetablesDto.Times)
        {
            result.Data.Add(new DoctorTimetablesTimeEntity()
            {
                Id = Guid.NewGuid().ToString(),
                IdDoctorTimeTablesDate = doctorId,
                Time = item,
                CreateDate = DateTime.Now
            });
        }
        
        return result;
    }

    public ResultDto<DoctorTimetablesDateEntity> CreateEntity(DoctorTimetablesDateEntity doctorTimetablesDateEntity, List<DoctorTimetablesTimeEntity> doctorTimetablesTimeList)
    {
        var result = new ResultDto<DoctorTimetablesDateEntity>();

        return result;
    }
}
