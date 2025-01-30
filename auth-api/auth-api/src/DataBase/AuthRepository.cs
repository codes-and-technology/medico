using AuthEntitys;
using AuthInterface;

namespace DataBase;

public class AuthRepository(ApplicationDbContext context) : Repository<AuthEntity>(context), IAuthRepository
{
    
}