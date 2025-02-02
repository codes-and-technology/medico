using Entitys;

namespace DataBase.SqlServer;

public class DoctorRepository(ApplicationDbContext context) : Repository<UserEntity>(context), IDoctorRepository
{
}
