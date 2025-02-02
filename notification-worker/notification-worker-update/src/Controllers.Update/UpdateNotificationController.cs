using Entitys;
using Presenters;
using Gateways.Cache;
using Gateways.Database;
using UseCases.Update;

namespace Controllers.Update
{
    public class UpdateNotificationController(INotificationDBGateway notificationDBGateway,
                                         IUpdateNotificationUseCase updateNotificationUseCase,
                                         ICacheGateway<NotificationEntity> cache) : IUpdateNotificationController
    {
        private readonly INotificationDBGateway _notificationDBGateway = notificationDBGateway;
        private readonly IUpdateNotificationUseCase _updateNotificationUseCase = updateNotificationUseCase;
        private readonly ICacheGateway<NotificationEntity> _cache = cache;

        public async Task<UpdateResult<NotificationEntity>> UpdateAsync(NotificationEntity entity)
        {
            
            //entity.PhoneRegion = await GetOrUpdatePhoneRegionAsync(entity.PhoneRegion.RegionNumber);
            var result = _updateNotificationUseCase.Update(entity);

            if (result.Errors.Count > 0)
                return result;
            

            await _notificationDBGateway.UpdateAsync(entity);
            await _notificationDBGateway.CommitAsync();

            await _cache.ClearCacheAsync("Notifications");

            return result;
        }

        /*
        private async Task<PhoneRegionEntity> GetOrUpdatePhoneRegionAsync(short regionNumber)
        {
            var phoneRegion = await _phoneRegionDBGateway.GetByRegionNumberAsync(regionNumber);

            if (phoneRegion is null)
            {
                phoneRegion = new PhoneRegionEntity { CreatedDate = DateTime.Now, Id = Guid.NewGuid(), RegionNumber = regionNumber };
                await _phoneRegionDBGateway.AddAsync(phoneRegion);
            }

            return phoneRegion;
        }
        */
    }
}
