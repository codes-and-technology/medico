using CreateEntitys;
using CreateInterface.Controllers;
using CreateInterface.Gateway.Cache;
using CreateInterface.Gateway.DB;
using CreateInterface.UseCase;
using Presenters;

namespace CreateController
{
    public class CreateDoctorTimetablesController(
        ICreateDoctorTimetablesUseCase createDoctorTimetablesUseCase,
        ICacheGateway<DoctorTimetablesDateEntity> cache,
        IDoctorTimetablesDateDBGateway doctorTimetablesDateDbGateway,
        IDoctorTimetablesTimeDBGateway doctorTimetablesTimeDbGateway
    ) : ICreateDoctorTimetablesController
    {
        public async Task<CreateResult<DoctorTimetablesDateEntity>> CreateAsync(
            DoctorTimetablesDateEntity doctorTimetables)
        {
            CreateResult<DoctorTimetablesDateEntity> result = new();
            
            result = createDoctorTimetablesUseCase.Create(doctorTimetables);

            if (!result.Success)
            {
                throw new Exception("Objeto invalido");
            }

            await doctorTimetablesDateDbGateway.AddAsync(doctorTimetables);
            await doctorTimetablesTimeDbGateway.AddRangeAsync(doctorTimetables.DoctorTimetablesTimes);
            await doctorTimetablesDateDbGateway.CommitAsync();

            await cache.ClearCacheAsync("DoctorsTimetablesDate");


            return result;
        }
    }
}