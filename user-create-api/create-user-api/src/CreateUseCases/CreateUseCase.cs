using CreateController.Utils;
using CreateEntitys;
using CreateUseCases.Utils;
using Presenters;
using System.Globalization;
using System.Text;


namespace CreateUseCases;

public class CreateUseCase(UserDto userDto, UserEntity userEntity, string crm, decimal? amount, string specialty, int? score)
{
    public ResultDto<UserEntity> CreateUser()
    {
        var result = new ResultDto<UserEntity>();
        result.Valid(userDto);

        if (userEntity is not null && userDto.Email.ToLower().Equals(userEntity.Email.ToLower(), StringComparison.InvariantCultureIgnoreCase))
        {
            result.Errors.Add("Email já existe");
        }
        if (!CpfUtils.ValidateCpf(userDto.DocumentNumber))
        {
            result.Errors.Add("CPF inválido");
        }

        if (!string.IsNullOrEmpty(crm))
        {
            if (!amount.HasValue)
                result.Errors.Add("Valor da consulta é obrigatório");            
            if (string.IsNullOrEmpty(specialty))
                result.Errors.Add("Precisa informar a especialidade");
            if (!score.HasValue)
                result.Errors.Add("Precisa informar a avaliação");
        }

        return result.Errors.Count > 0 ? result : CreateUserEntity(crm);
    }

    public ResultDto<AuthEntity> CreateAuth(UserEntity currentUser, string password)
    {
        ResultDto<AuthEntity> result = new();
        result.Valid(currentUser);

        AuthEntity authEntity = new()
        {
            Id = Guid.NewGuid().ToString(),
            CreateDate = DateTime.Now,
            Password = SecurityUtils.HashPassword(password),
            IdUser = currentUser.Id,
            LastLoginDate = DateTime.Now,
        };

        result.Data = authEntity;
        return result;
    }

    private ResultDto<UserEntity> CreateUserEntity(string crm)
    {
        specialty = NormalizeText(specialty);
        var result = new ResultDto<UserEntity>();
        var user = new UserEntity
        {
            Id = Guid.NewGuid().ToString(),
            Name = userDto.Name,
            Email = userDto.Email,
            CreateDate = DateTime.Now,
            CRM = crm,
            CPF = userDto.DocumentNumber,
            Amount = amount,
            Score = score,
            Specialty = specialty,
        };

        result.Data = user;
        return result;
    }

    private string NormalizeText(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        string normalizedString = input.Normalize(NormalizationForm.FormD);
        StringBuilder sb = new();

        foreach (char c in normalizedString)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
            {
                sb.Append(c);
            }
        }
        return sb.ToString().ToUpperInvariant();
    }
}
