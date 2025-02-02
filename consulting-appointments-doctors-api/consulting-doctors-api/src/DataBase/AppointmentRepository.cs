using ConsultingEntitys;
using ConsultingInterface;

namespace DataBase;

public class AppointmentRepository(ApplicationDbContext context) : Repository<AppointmentEntity>(context), IAppointmentRepository
{
}