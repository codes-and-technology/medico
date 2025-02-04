using Entitys;

namespace DataBase.SqlServer;

public class PatientRepository(ApplicationDbContext context) : Repository<UserEntity>(context), IPatientRepository
{
}
