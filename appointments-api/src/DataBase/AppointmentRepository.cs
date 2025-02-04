using Entitys;
using Interfaces;

namespace DataBase;

public class AppointmentRepository(ApplicationDbContext context) : Repository<AppointmentEntity>(context), IAppointmentRepository
{
}