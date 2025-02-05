using Entitys;
using Interfaces;

namespace DataBase.SqlServer;

public class NotificationRepository(ApplicationDbContext context) : Repository<NotificationEntity>(context), INotificationRepository
{
}
