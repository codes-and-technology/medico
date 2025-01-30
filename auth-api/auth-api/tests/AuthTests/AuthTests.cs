using System.Linq.Expressions;
using CreateController;
using CreateEntitys;
using CreateInterface;
using Moq;
using Presenters;

namespace UserApiCreateTests
{
    public class CreateUserTests
    {
        [Theory]
        [InlineData("teste@teste.com", "123456")]
        public async Task When_Login_ShouldBe_Ok(string email, string password)
        {
            var userDbGateway = new Mock<IUserDBGateway>();
            var authDbGateway = new Mock<IAuthDBGateway>();

            userDbGateway.Setup(s => s.FirstOrDefaultAsync(It.IsAny<Expression<Func<UserEntity, bool>>>()))
                .ReturnsAsync(new UserEntity { Email = "teste@teste.com", Auth = new AuthEntity { Password = "123456" } });
            var createContactController = new CreateUserController(userDbGateway.Object, authDbGateway.Object);

            var result = await createContactController.AuthAsync(new LoginDto { Email = "teste@teste.com", Password = "123456" });

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("teste@teste.com", "123456")]
        public async Task When_Login_ShouldBe_Error(string email, string password)
        {
            var userDbGateway = new Mock<IUserDBGateway>();
            var authDbGateway = new Mock<IAuthDBGateway>();

            userDbGateway.Setup(s => s.FirstOrDefaultAsync(It.IsAny<Expression<Func<UserEntity, bool>>>()))
                .ReturnsAsync(new UserEntity { Email = "teste@teste.com", Auth = new AuthEntity { Password = "123456" } });
            var createContactController = new CreateUserController(userDbGateway.Object, authDbGateway.Object);

            var result = await createContactController.AuthAsync(new LoginDto { Email = "teste@teste.com", Password = "0" });

            Assert.False(result.Success);
        }
    }
}