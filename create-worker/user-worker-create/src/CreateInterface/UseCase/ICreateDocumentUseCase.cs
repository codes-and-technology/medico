using CreateEntitys;
using Presenters;

namespace CreateInterface.UseCase;

public interface ICreateDocumentUseCase
{
    CreateResult<DocumentEntity> Create(int typeId, string value, Guid userId);
}