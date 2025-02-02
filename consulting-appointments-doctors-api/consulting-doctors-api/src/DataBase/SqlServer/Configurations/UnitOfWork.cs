﻿using ConsultingInterface;

namespace DataBase.SqlServer.Configurations;

public class UnitOfWork : IUnitOfWork
{

    private readonly ApplicationDbContext _dbContext;
    public IUserRepository Users { get; }
    public IDoctorsTimetablesDateRepository DoctorsTimetablesDate { get; }
    public IDoctorsTimetablesTimesRepository DoctorsTimetablesTimes { get; }

    public UnitOfWork(ApplicationDbContext dbContext,
                      IUserRepository userRepository, 
                      IDoctorsTimetablesDateRepository doctorsTimetablesDateRespository,
                      IDoctorsTimetablesTimesRepository doctorsTimetablesTimesRespository)
    {
        _dbContext = dbContext;
        Users = userRepository;
        DoctorsTimetablesDate = doctorsTimetablesDateRespository;
        DoctorsTimetablesTimes = doctorsTimetablesTimesRespository;
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
