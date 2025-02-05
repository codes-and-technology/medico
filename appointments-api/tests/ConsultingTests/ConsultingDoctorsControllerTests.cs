using Controllers;
using Entitys;
using Interfaces;
using Moq;
using Presenters;
using System.Linq.Expressions;

namespace UnitTests;

public class ConsultingDoctorsControllerTests
{
    [Theory]
    [InlineData("true")]
    [InlineData("false")]
    public async Task Get_AllDoctors_Tests(string cacheExists)
    {
        Mock<IUserDBGateway> userDbGateway = new();
        Mock<ICache> cacheGateway = new();

        var userEntityList = new List<UserEntity>
        {
            new UserEntity()
            {
                Email = "test@email.com",
                Id = Guid.NewGuid().ToString(),
                CRM = "12342-SP",
                Name = "Michael"
            },
            new UserEntity()
            {
                Email = "test2@email.com",
                Id = Guid.NewGuid().ToString(),
                CRM = "332145-SP",
                Name = "Jose"
            },
            new UserEntity()
            {
                Email = "test3@email.com",
                Id = Guid.NewGuid().ToString(),
                CRM = "444434-SP",
                Name = "Marcio"
            }
        };

        var list = userEntityList.Select(s => new UserDto
        {
            Email = s.Email,
            CRM = s.CRM,
            Name = s.Name,
            Id = s.Id
        }).ToList();
        
        if (Convert.ToBoolean(cacheExists))
        {
            cacheGateway.Setup(s => s.GetCacheAsync(It.IsAny<string>())).ReturnsAsync(list);
        }

        userDbGateway.Setup(s => s.FindAllAsync(It.IsAny<Expression<Func<UserEntity, bool>>>())).ReturnsAsync(userEntityList);
        
        var controller = new ConsultingDoctorController(userDbGateway.Object, cacheGateway.Object);

        var result = await controller.ConsultingDoctorAsync();

        Assert.True(result.Data.Count > 0);
    }
}