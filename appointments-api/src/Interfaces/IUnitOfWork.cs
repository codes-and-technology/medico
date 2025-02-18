﻿namespace Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    IDoctorsTimetablesDateRepository DoctorsTimetablesDate { get; }
    IDoctorsTimetablesTimesRepository DoctorsTimetablesTimes { get; }
    IAppointmentRepository Appointment{ get; }
    Task<int> CommitAsync();
    Task ExecuteInTransactionAsync(Func<Task> action);
}

