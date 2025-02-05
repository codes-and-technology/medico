using Entitys;
using Interface;

namespace DataBase.SqlServer;

public class DoctorsTimetablesTimesRepository(ApplicationDbContext context) : Repository<DoctorsTimetablesTimesEntity>(context), IDoctorsTimetablesTimesRepository
{
}
