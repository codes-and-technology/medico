using Entitys;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.SqlServer.Configurations
{
    public class ApppointmentConfiguration : IEntityTypeConfiguration<AppointmentEntity>
    {
        public void Configure(EntityTypeBuilder<AppointmentEntity> builder)
        {
            builder.ToTable("Appointment");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.CreateDate).IsRequired();
            builder.Property(p => p.IdPatient).IsRequired();
            builder.Property(p => p.IdDoctor).IsRequired();
            builder.Property(p => p.IdDoctorTimetablesDate).IsRequired();
            builder.Property(p => p.IdDoctorTimetablesTime).IsRequired();

            builder.HasOne(o => o.Pacient)
                .WithMany(m => m.Appointments)
                .HasForeignKey(t => t.IdPatient)
                .OnDelete(DeleteBehavior.Restrict);
 
            builder.HasOne(o => o.Doctor)
                .WithMany(m => m.Appointments)
                .HasForeignKey(t => t.IdDoctor)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.TimetablesDate)
                .WithMany(m => m.Appointments)
                .HasForeignKey(t => t.IdDoctorTimetablesDate)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.TimetablesTimes)
                .WithMany(m => m.Appointments)
                .HasForeignKey(t => t.IdDoctorTimetablesTime)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
