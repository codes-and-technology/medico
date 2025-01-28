using CreateEntitys;
using CreateInterface.UseCase;
using Presenters;

namespace CreateUseCases.UseCase;

public class CreateDocumentUseCase : ICreateDocumentUseCase
{
    public CreateResult<DocumentEntity> Create(int typeId, string value, Guid userId, DocumentEntity documentEntity)
    {
        var result = new CreateResult<DocumentEntity>();
        if (documentEntity is not null)
        {
            result.Errors.Add("Documento já cadastrado");
        }

        var document = new DocumentEntity
        {
            Value = value,
            Id = Guid.NewGuid(),
            UserId = userId,
            CreatedDate = DateTime.Now,
            TypeDocumentId = typeId
        };
        
        result.Data = document;
        return result;
    }
}