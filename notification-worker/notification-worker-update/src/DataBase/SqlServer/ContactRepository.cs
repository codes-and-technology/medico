using Entitys;

namespace DataBase.SqlServer;

public class ContactRepository(ApplicationDbContext context) : Repository<ContactEntity>(context), IContactRepository
{
}
