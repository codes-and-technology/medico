using UpdateEntitys;
using UpdateInterface.DataBase;

namespace DataBase.SqlServer;

public class DoctorTimetablesTimeRepository(ApplicationDbContext context) : Repository<DoctorTimetablesTimeEntity>(context), IDoctorTimetablesTimeRepository
{
    
}