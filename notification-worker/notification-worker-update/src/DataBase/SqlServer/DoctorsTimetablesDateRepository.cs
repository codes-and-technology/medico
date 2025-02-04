using Entitys;

namespace DataBase.SqlServer;

public class DoctorsTimetablesDateRepository(ApplicationDbContext context) : Repository<DoctorsTimetablesDateEntity>(context), IDoctorsTimetablesDateRepository
{
}
