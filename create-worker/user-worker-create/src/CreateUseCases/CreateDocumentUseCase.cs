using CreateEntitys;
using CreateInterface.UseCase;
using Presenters;

namespace CreateUseCases.UseCase;

public class CreateDocumentUseCase : ICreateDocumentUseCase
{
    public CreateResult<DocumentEntity> Create(int typeId, string value, Guid userId)
    {
        var document = new DocumentEntity
        {
            Value = value,
            Id = Guid.NewGuid(),
            UserId = userId,
            CreatedDate = DateTime.Now,
            TypeDocumentId = typeId
        };
        
        return new CreateResult<DocumentEntity>(document);
    }
}