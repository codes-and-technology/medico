using ConsultingEntitys;
using ConsultingInterface;

namespace DataBase;

public class DoctorsTimetablesTimesRepository(ApplicationDbContext context) : Repository<DoctorsTimetablesTimesEntity>(context), IDoctorsTimetablesTimesRepository
{
    
}