using Entitys;
using Interfaces;

namespace DataBase;

public class DoctorsTimetablesTimesRepository(ApplicationDbContext context) : Repository<DoctorsTimetablesTimesEntity>(context), IDoctorsTimetablesTimesRepository
{
    
}