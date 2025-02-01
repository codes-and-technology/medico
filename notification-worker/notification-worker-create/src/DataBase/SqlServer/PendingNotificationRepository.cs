using CreateEntitys;
using CreateInterface.DataBase;

namespace DataBase.SqlServer;

public class PendingNotificationRepository(ApplicationDbContext context) : Repository<PendingNotificationEntity>(context), IPendingNotificationRepository
{

}