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

    public async Task<DocumentEntity> FirstOrDefaultAsync(string value, int typeId)
    {
        return await Uow.Documents.FirstOrDefaultAsync(x => x.Value.Equals(value) && x.TypeDocumentId == typeId);
    }

    public async Task AddRangeAsync(List<DocumentEntity> documentList)
    {
        await Uow.Documents.AddRageAsync(documentList);
    }
}
