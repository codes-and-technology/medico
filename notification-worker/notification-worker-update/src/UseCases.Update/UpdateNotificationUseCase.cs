using Presenters;
using Entitys;

namespace UseCases.Update
{
    public class UpdateNotificationUseCase : IUpdateNotificationUseCase
    {
        public UpdateResult<NotificationEntity> Update(NotificationEntity entity)
        {
            var result = new UpdateResult<NotificationEntity>(entity);
            result.Valid(entity);

            /*
            if (entity.PhoneRegion?.Id == Guid.Empty)
                result.Errors.Add("O DDD deve ser informado");
            */

            return result;
        }
    }
}
