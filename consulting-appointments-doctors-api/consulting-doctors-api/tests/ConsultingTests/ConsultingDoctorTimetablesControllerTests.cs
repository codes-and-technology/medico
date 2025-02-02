using ConsultingController;
using ConsultingEntitys;
using ConsultingInterface;
using Moq;
using System.Linq.Expressions;

namespace ConsultingTests;

public class ConsultingDoctorTimetablesControllerTests
{
    private readonly Mock<IDoctorsTimetablesDateDBGateway> _mockDoctorsTimetablesDateDBGateway;
    private readonly Mock<IDoctorsTimetablesTimesDBGateway> _mockDoctorsTimetablesTimesDBGateway;
    private readonly Mock<IAppointmentDBGateway> _mockAppointmentDBGateway;
    private readonly ConsultingDoctorTimetablesController _controller;

    public ConsultingDoctorTimetablesControllerTests()
    {
        _mockDoctorsTimetablesDateDBGateway = new Mock<IDoctorsTimetablesDateDBGateway>();
        _mockDoctorsTimetablesTimesDBGateway = new Mock<IDoctorsTimetablesTimesDBGateway>();
        _mockAppointmentDBGateway = new Mock<IAppointmentDBGateway>();
        _controller = new ConsultingDoctorTimetablesController(
            _mockDoctorsTimetablesDateDBGateway.Object,
            _mockDoctorsTimetablesTimesDBGateway.Object,
            _mockAppointmentDBGateway.Object
        );
    }

    [Fact]
    public async Task ConsultingTimetablesAsync_ShouldReturnEmptyResult_WhenNoTimetablesFound()
    {
        // Arrange
        var idDoctor = "doctor1";
        _mockDoctorsTimetablesDateDBGateway.Setup(x => x.FindAllAsync(It.IsAny<Expression<Func<DoctorsTimetablesDateEntity, bool>>>()))
            .ReturnsAsync(new List<DoctorsTimetablesDateEntity>());

        // Act
        var result = await _controller.ConsultingTimetablesAsync(idDoctor);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result.Data);
    }

    [Fact]
    public async Task ConsultingTimetablesAsync_ShouldReturnTimetables_WhenTimetablesFound()
    {
        // Arrange
        var idDoctor = "doctor1";
        var doctorsTimetablesDateEntities = new List<DoctorsTimetablesDateEntity>
        {
            new DoctorsTimetablesDateEntity { Id = "1", IdDoctor = idDoctor, AvailableDate = DateTime.Now.AddDays(1) }
        };
        var doctorsTimetablesTimesEntities = new List<DoctorsTimetablesTimesEntity>
        {
            new DoctorsTimetablesTimesEntity { Id = "1", IdDoctorsTimetablesDate = "1", Time = "10:00" }
        };
        var appointmentEntities = new List<AppointmentEntity>();

        _mockDoctorsTimetablesDateDBGateway.Setup(x => x.FindAllAsync(It.IsAny<Expression<Func<DoctorsTimetablesDateEntity, bool>>>()))
            .ReturnsAsync(doctorsTimetablesDateEntities);

        _mockDoctorsTimetablesTimesDBGateway.Setup(x => x.FindAsync(It.IsAny<Expression<Func<DoctorsTimetablesTimesEntity, bool>>>()))
            .ReturnsAsync(doctorsTimetablesTimesEntities);

        _mockAppointmentDBGateway.Setup(x => x.FindAllAsync(It.IsAny<Expression<Func<AppointmentEntity, bool>>>()))
            .ReturnsAsync(appointmentEntities);

        // Act
        var result = await _controller.ConsultingTimetablesAsync(idDoctor);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result.Data);
        Assert.Single(result.Data.First().TimeList);
    }

    [Fact]
    public async Task ConsultingTimetablesAsync_ShouldFilterOutTimetablesWithNoTimes()
    {
        // Arrange
        var idDoctor = "doctor1";
        var doctorsTimetablesDateEntities = new List<DoctorsTimetablesDateEntity>
        {
            new DoctorsTimetablesDateEntity { Id = "1", IdDoctor = idDoctor, AvailableDate = DateTime.Now.AddDays(1) }
        };
        var doctorsTimetablesTimesEntities = new List<DoctorsTimetablesTimesEntity>();
        var appointmentEntities = new List<AppointmentEntity>();

        _mockDoctorsTimetablesDateDBGateway.Setup(x => x.FindAllAsync(It.IsAny<Expression<Func<DoctorsTimetablesDateEntity, bool>>>()))
            .ReturnsAsync(doctorsTimetablesDateEntities);

        _mockDoctorsTimetablesTimesDBGateway.Setup(x => x.FindAsync(It.IsAny<Expression<Func<DoctorsTimetablesTimesEntity, bool>>>()))
            .ReturnsAsync(doctorsTimetablesTimesEntities);

        _mockAppointmentDBGateway.Setup(x => x.FindAllAsync(It.IsAny<Expression<Func<AppointmentEntity, bool>>>()))
            .ReturnsAsync(appointmentEntities);

        // Act
        var result = await _controller.ConsultingTimetablesAsync(idDoctor);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result.Data);
    }
}
