namespace DataBase.SqlServer.Configurations;

public interface IUnitOfWork : IDisposable
{
    //IContactRepository Contacts { get; }
    //IPhoneRegionRepository PhoneRegions { get; }

    INotificationRepository Notifications { get; }
    IAppointmentRepository Appointments { get; }
    IDoctorsTimetablesTimesRepository TimetablesTimes { get; }
    IDoctorsTimetablesDateRepository TimetablesDates { get; }
    IPatientRepository Patients { get; }
    IDoctorRepository Doctors { get; }



    Task<int> CommitAsync();
}

