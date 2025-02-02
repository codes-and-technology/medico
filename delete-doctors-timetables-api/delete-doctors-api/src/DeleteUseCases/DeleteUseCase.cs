using DeleteEntitys;
using Presenters;

namespace DeleteUseCases;

public class DeleteUseCase(DeleteDoctorTimetablesDto deleteDoctorTimetablesDto, 
    ConsultingDoctorTimetablesDateDto doctoTimetables)
{
    public ResultDto<List<DoctorTimetablesTimeEntity>> DeleteDoctorTimetablesTime()
    {
        var result = new ResultDto<List<DoctorTimetablesTimeEntity>>
        {
            Data = []
        };

        if (doctoTimetables is not null && string.IsNullOrEmpty(doctoTimetables.IdDoctor) || string.IsNullOrEmpty(doctoTimetables.Id) || string.IsNullOrEmpty(doctoTimetables.Date))
        {
            result.Errors.Add("Não existe horário a ser atualizado, verfique e tente novamente");
            return result;
        }

        if (doctoTimetables.Id != deleteDoctorTimetablesDto.Id)
        {
            result.Errors.Add("ID da Data Disponível não encontrado");
        }

        bool hasDuplicates = deleteDoctorTimetablesDto.TimeList.GroupBy(x => x.Id).Any(g => g.Count() > 1);
        bool hasTimeDuplicates = deleteDoctorTimetablesDto.TimeList.GroupBy(x => x.Time).Any(g => g.Count() > 1);

        if (hasDuplicates)
            result.Errors.Add("Existe ID repetido, verifique e tente novamente");

        if (hasTimeDuplicates)
            result.Errors.Add("Existe horário repetido, verifique e tente novamente");


        foreach (var item in deleteDoctorTimetablesDto.TimeList)
        {
            if (!doctoTimetables.TimeList.Exists(a => a.Id == item.Id && a.IdDoctorsTimetablesDate == deleteDoctorTimetablesDto.Id))
                result.Errors.Add("ID do Horário não encontrado");
                
            if (doctoTimetables.TimeList.Any(a => a.Time == item.Time && a.IdDoctorsTimetablesDate == deleteDoctorTimetablesDto.Id))
                result.Errors.Add("Horário já cadastrado");
        }

        if (result.Errors.Any())
            return result;

        foreach (var item in deleteDoctorTimetablesDto.TimeList)
        {
            result.Data.Add(new DoctorTimetablesTimeEntity()
            {
                Id = item.Id,
                IdDoctorsTimetablesDate = deleteDoctorTimetablesDto.Id,
                Time = item.Time,
            });
        }
        
        return result;
    }

    public ResultDto<DoctorTimetablesDateEntity> DeleteEntity(string doctorId, string id, List<DoctorTimetablesTimeEntity> doctorTimetablesTimeList)
    {
        var result = new ResultDto<DoctorTimetablesDateEntity>
        {
            Data = new DoctorTimetablesDateEntity
            {
                DoctorTimetablesTimes = [.. doctorTimetablesTimeList],
                IdDoctor = doctorId,
                Id = id,
            }
        };

        return result;
    }
}
