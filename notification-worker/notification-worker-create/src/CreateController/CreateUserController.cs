using CreateEntitys;
using CreateInterface.Controllers;
using CreateInterface.Gateway.Cache;
using CreateInterface.Gateway.DB;
using CreateInterface.UseCase;
using Presenters;

namespace CreateController
{
    public class CreateUserController(
        ICreateUserUseCase createUserUseCase,
        ICacheGateway<NotificationDto> cache,
        IUserDBGateway userDbGateway
        ) : ICreateUserController
    {
        private readonly ICreateUserUseCase _createUserUseCase = createUserUseCase;
        private readonly ICacheGateway<NotificationDto> _cache = cache;
        private readonly IUserDBGateway _userDbGateway = userDbGateway;

        public async Task<CreateResult<NotificationEntity>> CreateAsync(NotificationDto notificationDto)
        {
            List<NotificationEntity> notificationList = new List<NotificationEntity>();
            /*
            var notificationExists = await _userDbGateway.FirstOrDefaultAsync(x => x.Email.Equals((notificationDto.Email)));
            notificationList.Add(notificationExists);
            
            if (NotificationDto.UserType == UserType.Doctor)
            {
                var crmExists  = await _userDbGateway.FirstOrDefaultAsync(f => f.CRM == NotificationDto.Crm);
                userList.Add(crmExists);
            }
            */

            var result = _createUserUseCase.Create(notificationDto, notificationList);

            if (result.Errors.Count > 0)
                return result;

            await _userDbGateway.CommitAsync();

            await _cache.ClearCacheAsync("Notification");
            return result;
            
        }
    }
}
