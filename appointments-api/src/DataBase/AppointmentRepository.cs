using Entitys;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataBase;

public class AppointmentRepository(ApplicationDbContext context) : Repository<AppointmentEntity>(context), IAppointmentRepository
{
    public async Task<IEnumerable<AppointmentReportEntity>> FindReportAsync(string idPatient)
    {
        var sqlQuery = @"
            SELECT A.Id AS AG_ID,
                   A.IdPatient AS AG_IdPatient,
                   A.IdDoctor AS AG_IdDoctor,
                   A.IdDoctorsTimetablesDate AS AG_IdDoctorsTimetablesDate,
                   A.IdDoctorsTimetablesTime AS AG_IdDoctorsTimetablesTime,
                   A.Status AS AG_Status,
                   A.CreateDate AS AG_CreateDate,
                   A.DeleteDate AS AG_DeleteDate,
                   R.Id AS DO_Id,
                   R.Name AS DO_Name,
                   R.CPF AS DO_CPF,
                   R.Email AS DO_Email,
                   R.CRM AS DO_CRM,
                   R.CreateDate AS DO_CreateDate,
                   R.Amount AS DO_Amount,
                   R.Specialty AS DO_Specialty,
                   R.Score AS DO_Score,
                   P.Id AS PA_Id,
                   P.Name AS PA_Name,
                   P.CPF AS PA_CPF,
                   P.Email AS PA_Email,
                   P.CRM AS PA_CRM,
                   P.CreateDate AS PA_CreateDate,
                   P.Amount AS PA_Amount,
                   P.Specialty AS PA_Specialty,
                   P.Score AS PA_Score,
                   D.Id AS DT_Id,
                   D.IdDoctor AS DT_IdDoctor,
                   D.AvailableDate AS DT_AvailableDate,
                   D.CreateDate AS DT_CreateDate,
                   D.DeleteDate AS DT_DeleteDate,
                   T.Id AS TM_Id,
                   T.IdDoctorsTimetablesDate AS TM_IdDoctorsTimetablesDate,
                   T.Time AS TM_Time,
                   T.CreateDate AS TM_CreateDate,
                   T.DeleteDate AS TM_DeleteDate
            FROM Appointments A
            INNER JOIN Users R ON R.Id = A.IdDoctor
            INNER JOIN Users P ON P.Id = A.IdPatient
            INNER JOIN DoctorsTimetablesDate D ON D.Id = A.IdDoctorsTimetablesDate
            INNER JOIN DoctorsTimetablesTimes T ON T.Id = A.IdDoctorsTimetablesTime
            WHERE A.IdPatient = {0}";

        return await _context.AppoitmentReport.FromSqlRaw(sqlQuery, idPatient).ToListAsync();
    }
}