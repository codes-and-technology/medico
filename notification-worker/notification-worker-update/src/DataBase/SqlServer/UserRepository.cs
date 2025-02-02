using Entitys;

namespace DataBase.SqlServer;

public class UserRepository(ApplicationDbContext context) : Repository<UserEntity>(context), IUserRepository
{
}
