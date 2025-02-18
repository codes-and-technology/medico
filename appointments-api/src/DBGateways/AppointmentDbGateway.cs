﻿using Entitys;
using Interfaces;
using System.Linq.Expressions;

namespace DBGateways;

public class AppointmentDbGateway(IUnitOfWork unitOfWork) : BaseDB(unitOfWork), IAppointmentDBGateway
{
    public async Task AddAsync(AppointmentEntity entity) => await Uow.Appointment.AddAsync(entity);
    public async Task UpdateAsync(AppointmentEntity entity) => await Uow.Appointment.UpdateAsync(entity);
    public async Task<IEnumerable<AppointmentEntity>> FindAllAsync(Expression<Func<AppointmentEntity, bool>> predicate) => await Uow.Appointment.FindAllAsync(predicate);
    public async Task<IEnumerable<AppointmentReportEntity>> FindReportAsync(string idPatient) => await Uow.Appointment.FindReportAsync(idPatient);
}
