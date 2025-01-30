using AuthEntitys;
using AuthInterface;

namespace DataBase;

public class UserRepository(ApplicationDbContext context) : Repository<UserEntity>(context), IUserRepository
{
    
}