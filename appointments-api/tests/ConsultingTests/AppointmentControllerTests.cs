using System.Linq.Expressions;
using Controllers;
using Entitys;
using Interfaces;
using Moq;

namespace UnitTests;

public class AppointmentControllerTests
{
    [Fact]
    public async Task Appointment_Test_Ok()
    {
        Mock<IDoctorsTimetablesDateDBGateway> doctorsTimetablesDateDBGateway = new();
        Mock<IDoctorsTimetablesTimesDBGateway> doctorsTimetablesTimesDBGateway = new();
        Mock<IAppointmentDBGateway> appointmentDBGateway = new();
        Mock<ICreateAppointmentQueueGateway> createAppointmentQueueGateway = new();
        Mock<IUserDBGateway> userDBGateway = new();
        var id = Guid.NewGuid().ToString();
        var patientId = Guid.NewGuid().ToString();

        var list = new List<AppointmentEntity>();
        list.Add(new AppointmentEntity
        {
            Id = id,
            IdDoctor = Guid.NewGuid().ToString(),
            IdPatient = patientId,
            CreateDate = DateTime.Now,
            IdDoctorsTimetablesDate = "1",
            IdDoctorsTimetablesTime = "1",
            Status = "PENDENTE"
        });
        
        appointmentDBGateway.Setup(s => s.FindAllAsync(It.IsAny<Expression<Func<AppointmentEntity, bool>>>())).ReturnsAsync(list);
        
        var controller = new AppointmentController(doctorsTimetablesDateDBGateway.Object,
            doctorsTimetablesTimesDBGateway.Object,
            appointmentDBGateway.Object,
            createAppointmentQueueGateway.Object,
            userDBGateway.Object);
        
        var result = await controller.DeleteAppointment(id, patientId);
        

        Assert.True(result.Success);
    }
    
    [Fact]
    public async Task Appointment_Test_Error()
    {
        Mock<IDoctorsTimetablesDateDBGateway> doctorsTimetablesDateDBGateway = new();
        Mock<IDoctorsTimetablesTimesDBGateway> doctorsTimetablesTimesDBGateway = new();
        Mock<IAppointmentDBGateway> appointmentDBGateway = new();
        Mock<ICreateAppointmentQueueGateway> createAppointmentQueueGateway = new();
        Mock<IUserDBGateway> userDBGateway = new();
        var id = Guid.NewGuid().ToString();
        var patientId = Guid.NewGuid().ToString();

        var list = new List<AppointmentEntity>();
        list.Add(new AppointmentEntity
        {
            Id = id,
            IdDoctor = Guid.NewGuid().ToString(),
            IdPatient = Guid.NewGuid().ToString(),
            CreateDate = DateTime.Now,
            IdDoctorsTimetablesDate = "1",
            IdDoctorsTimetablesTime = "1",
            Status = "PENDENTE"
        });
        
        appointmentDBGateway.Setup(s => s.FindAllAsync(It.IsAny<Expression<Func<AppointmentEntity, bool>>>())).ReturnsAsync(list);
        
        var controller = new AppointmentController(doctorsTimetablesDateDBGateway.Object,
            doctorsTimetablesTimesDBGateway.Object,
            appointmentDBGateway.Object,
            createAppointmentQueueGateway.Object,
            userDBGateway.Object);
        
        var result = await controller.DeleteAppointment(id, patientId);
        

        Assert.False(result.Success);
    }
}