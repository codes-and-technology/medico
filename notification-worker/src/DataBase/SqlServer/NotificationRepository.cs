using Entitys;
using Interface;

namespace DataBase.SqlServer;

public class NotificationRepository(ApplicationDbContext context) : Repository<NotificationEntity>(context), INotificationRepository
{
}
