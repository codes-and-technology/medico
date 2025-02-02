using DeleteEntitys;
using Presenters;

namespace DeleteInterface.UseCase;

public interface IDeleteDoctorTimetablesUseCase
{
    DeleteResult<DoctorTimetablesDateEntity> Delete(DoctorTimetablesDateEntity doctorTimetables,
        List<DoctorTimetablesTimeEntity> dbList, List<DoctorTimetablesDateEntity> doctorTimetablesDateEntityList);   
    DeleteResult<DoctorTimetablesDateEntity> DeleteFullList(DoctorTimetablesDateEntity doctorTimetables, List<DoctorTimetablesTimeEntity> dbList, DoctorTimetablesDateEntity doctorTimetablesDateEntity);
}