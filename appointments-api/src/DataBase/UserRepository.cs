using Entitys;
using Interfaces;

namespace DataBase;

public class UserRepository(ApplicationDbContext context) : Repository<UserEntity>(context), IUserRepository
{
    
}