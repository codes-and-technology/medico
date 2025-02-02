using Entitys;

namespace DataBase.SqlServer;

public class DoctorsTimetablesTimesRepository(ApplicationDbContext context) : Repository<DoctorsTimetablesTimesEntity>(context), IDoctorsTimetablesTimesRepository
{
}
