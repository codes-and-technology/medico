using UpdateEntitys;

namespace UpdateInterface.Gateway.DB;

public interface IDoctorTimetablesTimeDBGateway: IBaseDB
{
    Task UpdateRangeAsync(List<DoctorTimetablesTimeEntity> entityList);
    void Update(DoctorTimetablesTimeEntity entity);
}
