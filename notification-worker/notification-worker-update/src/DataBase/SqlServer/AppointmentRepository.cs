using Entitys;

namespace DataBase.SqlServer;

public class AppointmentRepository(ApplicationDbContext context) : Repository<AppointmentEntity>(context), IAppointmentRepository
{
}
