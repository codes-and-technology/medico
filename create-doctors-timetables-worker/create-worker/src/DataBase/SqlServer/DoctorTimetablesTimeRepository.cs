using CreateEntitys;
using CreateInterface.DataBase;

namespace DataBase.SqlServer;

public class DoctorTimetablesTimeRepository(ApplicationDbContext context) : Repository<DoctorTimetablesTimeEntity>(context), IDoctorTimetablesTimeRepository
{
    
}