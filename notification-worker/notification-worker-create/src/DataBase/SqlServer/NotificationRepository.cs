using CreateEntitys;
using CreateInterface.DataBase;

namespace DataBase.SqlServer;

public class NotificationRepository(ApplicationDbContext context) : Repository<NotificationEntity>(context), INotificationRepository
{
    
}