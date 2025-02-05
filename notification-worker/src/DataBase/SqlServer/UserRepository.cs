using Entitys;
using Interface;

namespace DataBase.SqlServer;

public class UserRepository(ApplicationDbContext context) : Repository<UserEntity>(context), IUserRepository
{
}
