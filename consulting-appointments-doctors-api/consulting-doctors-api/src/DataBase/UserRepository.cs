using ConsultingEntitys;
using ConsultingInterface;

namespace DataBase;

public class UserRepository(ApplicationDbContext context) : Repository<UserEntity>(context), IUserRepository
{
    
}