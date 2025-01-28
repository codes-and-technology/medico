using CreateEntitys;
using CreateInterface.DataBase;
using CreateInterface.Gateway.DB;

namespace DBGateways;

public class DocumentDBGateway(IUnitOfWork unitOfWork) : BaseDB(unitOfWork), IDocumentDBGateway
{
    public async Task AddAsync(DocumentEntity entity)
    {
        await Uow.Documents.AddAsync(entity);
    }

    public async Task<DocumentEntity> FindByIdAsync(Guid id)
    {
        return await Uow.Documents.FindByIdAsync(id);
    }
}
