using CreateEntitys;
using CreateInterface.Controllers;
using CreateInterface.Gateway.Queue;
using Presenters;

namespace QueueGateways
{
    public class CreateUserGateway(ICreateUserController createUserController) : ICreateUserGateway
    {
        private readonly ICreateUserController _createUserController = createUserController;

        public async Task<CreateResult<NotificationEntity>> CreateAsync(NotificationDto entity)
        {
            return await _createUserController.CreateAsync(entity);
        }
    }
}
