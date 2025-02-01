using CreateEntitys;
using CreateInterface.UseCase;
using Presenters;

namespace CreateUseCases.UseCase;

public class CreateUserUseCase : ICreateUserUseCase
{
    public CreateResult<UserEntity> Create(UserDto entity, List<UserEntity> list)
    {
        var result = new CreateResult<UserEntity>();

        if (list.Exists(e => e.Email.Equals(entity.Email, StringComparison.InvariantCultureIgnoreCase)))
        {
            result.Errors.Add("Email já em uso");
            return result;
        }
        if (list.Exists(e => e.CRM == entity.Crm || e.CPF == entity.DocumentNumber))
        {            
            result.Errors.Add("Documentos já em uso");
            return result;
        }

        result.Data = new()
        {
            Email = entity.Email,
            Id = entity.Id,
            Name = entity.Name,
            CPF = entity.DocumentNumber,
            CreateDate = DateTime.Now,
            CRM = string.IsNullOrEmpty(entity.Crm) ? string.Empty : entity.Crm,
        };

        result.Valid(entity);

        return result;
    }
}