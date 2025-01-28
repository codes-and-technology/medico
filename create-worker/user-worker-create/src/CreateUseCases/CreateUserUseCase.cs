using CreateEntitys;
using CreateInterface.UseCase;
using Presenters;

namespace CreateUseCases.UseCase;

public class CreateUserUseCase : ICreateUserUseCase
{
    public CreateResult<UserEntity> Create(UserDto entity)
    {
        var result = new CreateResult<UserEntity>(new()
        {
            Email = entity.Email,
            Id = entity.Id,
            Name = entity.Name,
            DocumentNumber = entity.DocumentNumber,
            CreatedDate = DateTime.Now,
        });
        result.Valid(entity);

        return result;
    }
}