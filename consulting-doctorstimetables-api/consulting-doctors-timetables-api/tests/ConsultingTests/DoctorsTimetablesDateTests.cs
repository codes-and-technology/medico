using ConsultingEntitys;
using ConsultingInterface;
using Moq;
using Presenters;

namespace ConsultingTests;

public class DoctorsTimetablesDateTests
{
    [Theory]
    [InlineData("true")]
    [InlineData("false")]
    public async Task Get_AllDoctors_Tests(string cacheExists)
    {
        Mock<IDoctorsTimetablesDateDBGateway> doctorsTimetablesDateDBGateway = new();
        Mock<IDoctorsTimetablesTimesDBGateway> doctorsTimetablesTimesDBGateway = new();
        Mock<ICache<DoctorsTimetablesDateDto>> cacheGateway = new();

        var doctorsTimetablesDateList = new List<DoctorsTimetablesDateEntity>
        {
            new DoctorsTimetablesDateEntity
            {
                Id = "1",
                IdDoctor = "1",
                AvailableDate = DateTime.Now
            }
        };

        var cacheList = doctorsTimetablesDateList.Select(s => new DoctorsTimetablesDateDto
        {
            Id = s.Id,
            IdDoctor = s.IdDoctor,
            Date = s.AvailableDate.ToString("dd/MM/yyyy")            
        }).ToList();

        var doctorsTimetablesTimesList = new List<DoctorsTimetablesTimesEntity>
        {
            new DoctorsTimetablesTimesEntity
            {
                Id = "1",
                IdDoctorsTimetablesDate = "1",
                Time = "08:00"
            }
        };

        if (Convert.ToBoolean(cacheExists))
            cacheGateway.Setup(s => s.GetCacheAsync(It.IsAny<string>())).ReturnsAsync(cacheList);
        else
            cacheGateway.Setup(s => s.GetCacheAsync(It.IsAny<string>())).ReturnsAsync(new List<DoctorsTimetablesDateDto>());

        doctorsTimetablesDateDBGateway.Setup(s => s.FindDoctorsTimetablesDateByIdDoctorAvailableAsync("1")).ReturnsAsync(doctorsTimetablesDateList);
        doctorsTimetablesTimesDBGateway.Setup(s => s.FindAsync(t => t.IdDoctorsTimetablesDate == "1")).ReturnsAsync(doctorsTimetablesTimesList);

        var controller = new ConsultingController.ConsultingController(doctorsTimetablesDateDBGateway.Object, doctorsTimetablesTimesDBGateway.Object, cacheGateway.Object);

        var result = await controller.ConsultingDoctorsTimetablesDateAsync("1");

        Assert.True(result.Data.Count > 0);
    }
}