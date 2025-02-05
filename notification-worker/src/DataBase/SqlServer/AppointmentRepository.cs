using Entitys;
using Interface;

namespace DataBase.SqlServer;

public class AppointmentRepository(ApplicationDbContext context) : Repository<AppointmentEntity>(context), IAppointmentRepository
{
}
