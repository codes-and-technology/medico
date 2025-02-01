using ConsultingEntitys;
using ConsultingInterface;

namespace DBGateways;

public class DoctorsTimetablesDateDBGateway(IUnitOfWork unitOfWork) : BaseDB(unitOfWork), IDoctorsTimetablesDateDBGateway
{
    public Task<IEnumerable<DoctorsTimetablesDateEntity>> FindDoctorsTimetablesDateByIdDoctorAsync(string idDoctor)
    {
        return Uow.DoctorsTimetablesDate.GetAllAsync(d => d.Doctor.Id == idDoctor);
    }
}
