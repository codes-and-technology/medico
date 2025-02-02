using UpdateEntitys;
using UpdateInterface.Controllers;
using UpdateInterface.Gateway.Cache;
using UpdateInterface.Gateway.DB;
using UpdateInterface.UseCase;
using Presenters;

namespace UpdateController
{
    public class UpdateDoctorTimetablesController(
        IUpdateDoctorTimetablesUseCase updateDoctorTimetablesUseCase,
        ICacheGateway<DoctorTimetablesDateEntity> cache,
        IDoctorTimetablesDateDBGateway doctorTimetablesDateDbGateway,
        IDoctorTimetablesTimeDBGateway doctorTimetablesTimeDbGateway
    ) : IUpdateDoctorTimetablesController
    {
        public async Task<UpdateResult<DoctorTimetablesDateEntity>> UpdateAsync(
            DoctorTimetablesDateEntity doctorTimetables)
        {
            UpdateResult<DoctorTimetablesDateEntity> result = new();
            
            result = updateDoctorTimetablesUseCase.Update(doctorTimetables);

            if (!result.Success)
            {
                throw new Exception("Objeto invalido");
            }

            try
            {
                foreach (var item in result.Data.DoctorTimetablesTimes)
                {
                    doctorTimetablesTimeDbGateway.Update(item);

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
    }
}