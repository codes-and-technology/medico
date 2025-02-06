using System.Runtime.InteropServices.JavaScript;
using Controllers;
using Entitys;
using Interfaces;
using MimeKit;
using Moq;
using Org.BouncyCastle.Tls;
using Presenters;
using Xunit;

namespace NotificationWorker.Unit.Tests;

public class NotificationWorkerUnitTests
{
    [Fact]
    public async Task Controller_Tests_Ok()
    {
        Mock<INotificationDbGateway> dbGateway = new();
        Mock<INotificationUseCase> useCase = new();
        Mock<IEmailGateway> emailGateway = new();
        var controller = new NotificationController(dbGateway.Object, useCase.Object, emailGateway.Object);

        var dto = new CreatedAppointmentDto
        {
            Id = "1",
            AppointmentDate = "1",
            DoctorName = "Doctor Name",
            Status = "Status",
            DoctorEmail = "Doctor Email",
            PatientName = "Patient Name",
            IdDoctor = "2",
            IdPatient = "2",
            IdDoctorsTimetablesDate = "1",
            IdDoctorsTimetablesTime = "1",
        };

        useCase.Setup(s =>
            s.Notification(It.IsAny<CreatedAppointmentDto>())).Returns(new Result<CreatedAppointmentDto>
        {
            Data = new CreatedAppointmentDto
            {
                Id = "1",
                AppointmentDate = "1",
                DoctorName = "Doctor Name",
                Status = "Status",
                DoctorEmail = "Doctor Email",
                PatientName = "Patient Name",
                IdDoctor = "2",
                IdPatient = "2",
                IdDoctorsTimetablesDate = "1",
                IdDoctorsTimetablesTime = "1",
            }
        });
        emailGateway.Setup(s => s.NotificationAsync(It.IsAny<CreatedAppointmentDto>())).ReturnsAsync(new Result<MimeMessage>
        {
            Data = new MimeMessage
            {
                
            }
        });

        useCase.Setup(s => s.CreateEntity(It.IsAny<Result<MimeMessage>>(), It.IsAny<string>())).Returns(new Result<NotificationEntity>());
        
     

        await controller.NotificationAsync(dto);
    }


    [Fact]
    public async Task Controller_Tests_Error()
    {
        Mock<INotificationDbGateway> dbGateway = new();
        Mock<INotificationUseCase> useCase = new();
        Mock<IEmailGateway> emailGateway = new();

        useCase.Setup(s =>
            s.Notification(It.IsAny<CreatedAppointmentDto>())).Returns(new Result<CreatedAppointmentDto>
        {
            Errors = new List<string>()
            {
                "error"
            }
        });

        var controller = new NotificationController(dbGateway.Object, useCase.Object, emailGateway.Object);

        var dto = new CreatedAppointmentDto
        {
            Id = "1",
            AppointmentDate = "1",
            DoctorName = "Doctor Name",
            Status = "Status",
            DoctorEmail = string.Empty,
            PatientName = "Patient Name",
            IdDoctor = "2",
            IdPatient = "2",
            IdDoctorsTimetablesDate = "1",
            IdDoctorsTimetablesTime = "1",
        };
        await Assert.ThrowsAsync<Exception>(async () => await controller.NotificationAsync(dto));
    }
}