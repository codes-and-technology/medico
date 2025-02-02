using DeleteEntitys;
using DeleteInterface.Controllers;
using DeleteInterface.Gateway.Cache;
using DeleteInterface.Gateway.DB;
using DeleteInterface.UseCase;
using Presenters;

namespace DeleteController
{
    public class DeleteDoctorTimetablesController(
        IDeleteDoctorTimetablesUseCase deleteDoctorTimetablesUseCase,
        ICacheGateway<DoctorTimetablesDateEntity> cache,
        IDoctorTimetablesDateDBGateway doctorTimetablesDateDbGateway,
        IDoctorTimetablesTimeDBGateway doctorTimetablesTimeDbGateway
    ) : IDeleteDoctorTimetablesController
    {
        public async Task<DeleteResult<DoctorTimetablesDateEntity>> DeleteAsync(
            DoctorTimetablesDateEntity doctorTimetables)
        {
            DeleteResult<DoctorTimetablesDateEntity> result = new();

            try
            {
                
                if (!string.IsNullOrEmpty(doctorTimetables.Id))
                {
                    var doctorTimetablesDate = await doctorTimetablesDateDbGateway.FirstOrDefaultAsync(X => X.Id == doctorTimetables.Id && X.IdDoctor == doctorTimetables.IdDoctor);

                    var list = await doctorTimetablesTimeDbGateway.GetAllAsync(x => x.IdDoctorsTimetablesDate == doctorTimetables.Id);
                    result = deleteDoctorTimetablesUseCase.DeleteFullList(doctorTimetables, list, doctorTimetablesDate );

                    if (!result.Success)
                        throw new Exception("Registro não pertence ao médico");

                    UpdateList(list);

                    var doctorDate = await doctorTimetablesDateDbGateway
                            .FirstOrDefaultAsync(x => x.Id == doctorTimetables.Id);
                   
                    doctorDate.DeleteDate = DateTime.Now;
                    
                    doctorTimetablesDateDbGateway.Update(doctorDate);
                }
                else
                {
                    var list = new List<DoctorTimetablesTimeEntity>();
                    List<DoctorTimetablesDateEntity> doctorTimetablesDateEntityList = new();

                    foreach (var item in doctorTimetables.DoctorTimetablesTimes)
                    {
                        var doctorTimetablesDb = await doctorTimetablesTimeDbGateway.FirstOrDefaultAsync(x => x.Id == item.Id);
                        list.Add(doctorTimetablesDb);

                        var doctorTimetablesDate = await doctorTimetablesDateDbGateway.FirstOrDefaultAsync(X => X.Id == doctorTimetablesDb.IdDoctorsTimetablesDate && X.IdDoctor == doctorTimetables.IdDoctor);
                        doctorTimetablesDateEntityList.Add(doctorTimetablesDate);
                    }
                    
                    result = deleteDoctorTimetablesUseCase.Delete(doctorTimetables, list, doctorTimetablesDateEntityList);
                    if (!result.Success)
                        throw new Exception("Horário não pertence ao médico");
                    
                    UpdateList(result.Data.DoctorTimetablesTimes);

                    foreach (var item in doctorTimetablesDateEntityList)
                    {
                        var res = await doctorTimetablesTimeDbGateway.GetAllAsync(x => x.IdDoctorsTimetablesDate == item.Id);
                        if (res.Exists(x => !x.DeleteDate.HasValue))
                        {
                            continue;
                        }
                        else
                        {
                            item.DeleteDate = DateTime.Now;
                            doctorTimetablesDateDbGateway.Update(item);
                        }
                    }

                }

                await doctorTimetablesDateDbGateway.CommitAsync();

                await cache.ClearCacheAsync("DoctorsTimetablesDate");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return result;
        }

        private void UpdateList(List<DoctorTimetablesTimeEntity> list)
        {
            foreach (var item in list)
            {
                item.DeleteDate = DateTime.Now;
                doctorTimetablesTimeDbGateway.Update(item);
            }
        }
    }
}