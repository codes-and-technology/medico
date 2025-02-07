using CreateEntitys;
using CreateInterface.Controllers;
using CreateInterface.Gateway.Cache;
using CreateInterface.Gateway.DB;
using CreateInterface.UseCase;
using Presenters;
using Presenters.Enum;

namespace CreateController
{
    public class CreateUserController(
        ICreateUserUseCase createUserUseCase,
        ICacheGateway<UserDto> cache,
        IUserDBGateway userDbGateway
        ) : ICreateUserController
    {
        private readonly ICreateUserUseCase _createUserUseCase = createUserUseCase;
        private readonly ICacheGateway<UserDto> _cache = cache;
        private readonly IUserDBGateway _userDbGateway = userDbGateway;

        public async Task<CreateResult<UserEntity>> CreateAsync(UserDto userDto)
        {
            List<UserEntity> userList = new List<UserEntity>();
            var userExists = await _userDbGateway.FirstOrDefaultAsync(x => x.Email.Equals((userDto.Email)));
            userList.Add(userExists);
            
            var cpfExists = await _userDbGateway.FirstOrDefaultAsync(f => f.CPF == userDto.DocumentNumber);
            userList.Add(cpfExists);
            
            if (userDto.UserType == UserType.Doctor)
            {
                var crmExists  = await _userDbGateway.FirstOrDefaultAsync(f => f.CRM == userDto.Crm);
                userList.Add(crmExists);
            }

            var result = _createUserUseCase.Create(userDto, userList);

            if (result.Errors.Count > 0)
                return result;

            await _userDbGateway.CommitAsync();

            await _cache.ClearCacheAsync("Users");
            
            return result;
        }
    }
}
