using CreateEntitys;

namespace CreateInterface.Gateway.DB;

public interface IDocumentDBGateway: IBaseDB
{
    Task AddAsync(DocumentEntity entity);
    Task<DocumentEntity> FindByIdAsync(Guid id);
}