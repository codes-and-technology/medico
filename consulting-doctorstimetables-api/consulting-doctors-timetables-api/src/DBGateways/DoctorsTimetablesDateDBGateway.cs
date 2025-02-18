﻿using ConsultingEntitys;
using ConsultingInterface;

namespace DBGateways;

public class DoctorsTimetablesDateDBGateway(IUnitOfWork unitOfWork) : BaseDB(unitOfWork), IDoctorsTimetablesDateDBGateway
{
    public Task<IEnumerable<DoctorsTimetablesDateEntity>> FindDoctorsTimetablesDateByIdDoctorAvailableAsync(string idDoctor)
    {
        return Uow.DoctorsTimetablesDate.GetAllAsync(d => d.IdDoctor == idDoctor && !d.DeleteDate.HasValue);
    }
}
