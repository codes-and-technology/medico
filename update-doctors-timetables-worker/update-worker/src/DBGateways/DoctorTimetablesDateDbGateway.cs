using System.Linq.Expressions;
using UpdateEntitys;
using UpdateInterface.DataBase;
using UpdateInterface.Gateway.DB;

namespace DBGateways;

public class DoctorTimetablesDateDbGateway(IUnitOfWork unitOfWork) : BaseDB(unitOfWork), IDoctorTimetablesDateDBGateway
{
}
