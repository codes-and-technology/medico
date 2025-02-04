namespace DataBase.SqlServer.Configurations;

public class UnitOfWork : IUnitOfWork
{

    private readonly ApplicationDbContext _dbContext;
    //public IContactRepository Contacts { get; }
    //public IPhoneRegionRepository PhoneRegions { get; }
    public INotificationRepository Notifications { get; }
    public IAppointmentRepository Appointments { get; }
    public IDoctorsTimetablesTimesRepository TimetablesTimes { get; }
    public IDoctorsTimetablesDateRepository TimetablesDates { get; }
    public IPatientRepository Patients { get; }
    public IDoctorRepository Doctors { get; }


    public UnitOfWork(ApplicationDbContext dbContext,
                        //IContactRepository contactRepository,
                        //IPhoneRegionRepository phoneRegions,
                        INotificationRepository notificationRepository,
                        IAppointmentRepository appointmentRepository,
                        IDoctorsTimetablesTimesRepository timetablesTimesRepository,
                        IDoctorsTimetablesDateRepository timetablesDateRepository,
                        IPatientRepository patientRepository,
                        IDoctorRepository doctorRepository
                        )
    {
        _dbContext = dbContext;
        //Contacts = contactRepository;
        //PhoneRegions = phoneRegions;
        Notifications = notificationRepository;
        Appointments = appointmentRepository;
        TimetablesTimes = timetablesTimesRepository;
        TimetablesDates = timetablesDateRepository;
        Patients = patientRepository;
        Doctors = doctorRepository;

}

public async Task<int> CommitAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _dbContext.Dispose();
        }
    }
}
