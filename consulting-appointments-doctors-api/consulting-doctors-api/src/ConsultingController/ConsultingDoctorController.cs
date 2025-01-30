﻿using ConsultingInterface;
using ConsultingUseCases;
using Presenters;

namespace ConsultingController;
public class ConsultingDoctorController(IUserDBGateway userDbGateway, ICache cacheGateway) : IController
{
    public async Task<ResultDto<List<UserDto>>> ConsultingUserAsync()
    {
        var doctorCache = await cacheGateway.GetCacheAsync("Doctors");

        var useCase = new ConsultingUseCase();

        if (doctorCache is not null && doctorCache.Count > 0)
            return useCase.CreateConsultingFromCache(doctorCache);

        var doctorList = await userDbGateway.GetAllAsync();
        var result = useCase.CreateConsultingFromDb(doctorList);

        await cacheGateway.SaveCacheAsync("Doctors", result.Data);
        return result;
    }
}