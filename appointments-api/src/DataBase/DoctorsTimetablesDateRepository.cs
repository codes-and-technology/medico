using Entitys;
using Interfaces;

namespace DataBase;

public class DoctorsTimetablesDateRepository(ApplicationDbContext context) : Repository<DoctorsTimetablesDateEntity>(context), IDoctorsTimetablesDateRepository
{
    
}