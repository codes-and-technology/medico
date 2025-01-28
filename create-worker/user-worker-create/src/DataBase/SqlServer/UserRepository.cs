using CreateEntitys;
using CreateInterface.DataBase;

namespace DataBase.SqlServer;

public class UserRepository(ApplicationDbContext context) : Repository<UserEntity>(context), IUserRepository
{
    
}