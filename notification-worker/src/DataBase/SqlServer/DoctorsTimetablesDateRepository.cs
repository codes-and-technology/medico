using Entitys;
using Interface;

namespace DataBase.SqlServer;

public class DoctorsTimetablesDateRepository(ApplicationDbContext context) : Repository<DoctorsTimetablesDateEntity>(context), IDoctorsTimetablesDateRepository
{
}
