using CreateEntitys;
using CreateInterface;

namespace DataBase;

public class UserRepository(ApplicationDbContext context) : Repository<UserEntity>(context), IUserRepository
{
    
}