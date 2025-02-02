using ConsultingEntitys;
using ConsultingInterface;

namespace DataBase;

public class DoctorsTimetablesDateRepository(ApplicationDbContext context) : Repository<DoctorsTimetablesDateEntity>(context), IDoctorsTimetablesDateRepository
{
    
}