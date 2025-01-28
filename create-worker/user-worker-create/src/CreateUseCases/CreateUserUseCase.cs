using CreateEntitys;
using CreateInterface.UseCase;
using Presenters;

namespace CreateUseCases.UseCase;

public class CreateUserUseCase : ICreateUserUseCase
{
    public CreateResult<UserEntity> Create(UserDto entity, ApplicationUser applicationUser)
    {
        var result = new CreateResult<UserEntity>();

        if (applicationUser is not null)
        {            
            result.Errors.Add("Email já cadastrado");
            return result;
        }

        result.Data = new()
        {
            Email = entity.Email,
            Id = entity.Id,
            Name = entity.Name,
            DocumentNumber = entity.DocumentNumber,
            CreatedDate = DateTime.Now,
        };

        result.Valid(entity);

        return result;
    }
}