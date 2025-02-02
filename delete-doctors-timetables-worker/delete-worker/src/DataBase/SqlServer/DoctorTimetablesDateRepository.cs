using DeleteEntitys;
using DeleteInterface.DataBase;

namespace DataBase.SqlServer;

public class DoctorTimetablesDateRepository(ApplicationDbContext context) : Repository<DoctorTimetablesDateEntity>(context), IDoctorTimetablesDateRepository
{
    
}