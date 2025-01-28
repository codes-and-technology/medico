using CreateEntitys;
using CreateInterface.Controllers;
using CreateInterface.Gateway.Cache;
using CreateInterface.Gateway.DB;
using CreateInterface.UseCase;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Presenters;
using Presenters.Enum;

namespace CreateController
{
    public class CreateUserController(
        ICreateUserUseCase createUserUseCase,
        ICreateDocumentUseCase createDocumentUseCase,
        ICacheGateway<UserDto> cache,
        IDocumentDBGateway documentDbGateway,
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager

        ) : ICreateUserController
    {
        private readonly ICreateUserUseCase _createUserUseCase = createUserUseCase;
        private readonly ICacheGateway<UserDto> _cache = cache;
        private readonly ICreateDocumentUseCase _createDocumentUseCase = createDocumentUseCase;
        private readonly IDocumentDBGateway _documentDbGateway = documentDbGateway;
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly SignInManager<ApplicationUser> _signInManager = signInManager;

        public async Task<CreateResult<UserEntity>> CreateAsync(UserDto entity)
        {
            List<DocumentEntity> documentList = [];

            var userIdentity = await _userManager.FindByEmailAsync(entity.Email);
            var result = _createUserUseCase.Create(entity, userIdentity);

            var documentEntity = await _documentDbGateway.FirstOrDefaultAsync(entity.DocumentNumber, (int)TypeDocument.CPF);
            var document = _createDocumentUseCase.Create(
                typeId: 2, 
                value: entity.DocumentNumber, 
                userId: entity.Id,
                documentEntity: documentEntity
                );
            documentList.Add(document.Data);

            if (entity.UserType == UserType.Doctor)
            {
                documentEntity = await _documentDbGateway.FirstOrDefaultAsync(entity.Crm.ToString(), (int)TypeDocument.CRM);
                var crm = _createDocumentUseCase.Create(
                    typeId: 1,
                    value: entity.Crm.ToString(),
                    userId: entity.Id,
                    documentEntity: documentEntity
                );
                documentList.Add(crm.Data);
            }

            if (result.Errors.Count > 0)
                return result;
            
            var user = new ApplicationUser { UserName = entity.Email, Email = entity.Email };
            var userManger = await _userManager.CreateAsync(user, entity.Password);

            await AssignRole(entity.Email, role: entity.UserType == UserType.Doctor ? "DOCTOR" : "PATIENT");           

            if (userManger.Succeeded)
                await _signInManager.SignInAsync(user, isPersistent: false);
            else
                throw new Exception("Erro ao tentar criado usuário");

            await _documentDbGateway.AddRangeAsync(documentList);
            await _documentDbGateway.CommitAsync();

            await _cache.ClearCacheAsync("Users");

            //var doctors = await userManager.Users
            //    .Where(user => userManager.IsInRoleAsync(user, "DOCTOR").Result)
            //    .ToListAsync();

            return result;
        }

        private async Task AssignRole(string email, string role)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null && !await userManager.IsInRoleAsync(user, role))
                await userManager.AddToRoleAsync(user, role);
        }
    }
}
