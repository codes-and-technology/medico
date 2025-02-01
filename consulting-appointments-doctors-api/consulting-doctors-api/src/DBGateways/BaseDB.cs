using ConsultingInterface;

namespace DBGateways;

public class BaseDB(IUnitOfWork unitOfWork) : IBaseDB
{
    public readonly IUnitOfWork Uow = unitOfWork;
    
}