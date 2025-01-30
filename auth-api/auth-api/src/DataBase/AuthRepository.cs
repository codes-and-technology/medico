using CreateEntitys;
using CreateInterface;

namespace DataBase;

public class AuthRepository(ApplicationDbContext context) : Repository<AuthEntity>(context), IAuthRepository
{
    
}