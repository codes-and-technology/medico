using AuthControllers;
using AuthEntitys;
using AuthInterface;
using Microsoft.Extensions.Configuration;
using Moq;
using Presenters;
using System.Linq.Expressions;

namespace AuthTests
{
    public class AuthTests
    {
        private readonly IConfiguration _configuration;

        public AuthTests()
        {
            var inMemorySettings = new Dictionary<string, string> {
                    {"SecretJWT", "DALKSJDALKSDJNALSDNJASDJLASKDJASKDJBNASDKJSAD"}
                };

            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
        }

        [Theory]
        [InlineData("teste@teste.com", "123456")]
        public async Task When_Login_ShouldBe_Ok(string email, string password)
        {
            var userDbGateway = new Mock<IUserDBGateway>();
            var authDbGateway = new Mock<IAuthDBGateway>();

            userDbGateway.Setup(s => s.FirstOrDefaultAsync(It.IsAny<Expression<Func<UserEntity, bool>>>()))
                .ReturnsAsync(new UserEntity { Id = "aaaa", Email = "teste@teste.com" });

            authDbGateway.Setup(s => s.FirstOrDefaultAsync(It.IsAny<Expression<Func<AuthEntity, bool>>>()))
                .ReturnsAsync(new AuthEntity { Id = "aaaa", Password = "$2a$10$yIE1TQgmRJytR1XGN3Wmkufu2oGp0Kd7yruK6WyqX1Mg8xXQxIEfe" });

            var createContactController = new AuthController(userDbGateway.Object, authDbGateway.Object, _configuration);

            var result = await createContactController.AuthAsync(new LoginDto { Email = "teste@teste.com", Password = "string" });

            Assert.True(result.Success);
        }

        [Theory]
        [InlineData("teste@teste.com", "123456")]
        public async Task When_Login_ShouldBe_Error(string email, string password)
        {
            var userDbGateway = new Mock<IUserDBGateway>();
            var authDbGateway = new Mock<IAuthDBGateway>();

            userDbGateway.Setup(s => s.FirstOrDefaultAsync(It.IsAny<Expression<Func<UserEntity, bool>>>()))
                .ReturnsAsync(new UserEntity { Id = "aaaa", Email = "teste@teste.com", Auth = new AuthEntity { Password = "123456" } });

            authDbGateway.Setup(s => s.FirstOrDefaultAsync(It.IsAny<Expression<Func<AuthEntity, bool>>>()))
                .ReturnsAsync(new AuthEntity { Id = "aaaa", Password = "11111" });

            var createContactController = new AuthController(userDbGateway.Object, authDbGateway.Object, _configuration);

            var result = await createContactController.AuthAsync(new LoginDto { Email = "teste@teste.com", Password = "123456" });

            Assert.False(result.Success);
        }
    }
}