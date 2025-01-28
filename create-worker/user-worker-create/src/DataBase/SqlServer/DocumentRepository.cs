using CreateEntitys;
using CreateInterface.DataBase;

namespace DataBase.SqlServer;

public class DocumentRepository(ApplicationDbContext context) : Repository<DocumentEntity>(context), IDocumentRepository
{
    
}