using CreateController;
using CreateInterface;
using Moq;
using Presenters;

namespace UserApiCreateTests
{
    public class CreateUserTests
    {
        [Theory]
        [InlineData("usuario teste", "40993229808", "teste@teste.com")]
        public async Task When_CreateContact_ShouldBe_Ok(string name, string document, string email)
        {
            var mockIUserQueueGateway = new Mock<IUserQueueGateway>();
            var mockIUserConsultingGateway = new Mock<IUserConsultingGateway>();

            mockIUserConsultingGateway.Setup(s => s.GetUser(It.IsAny<string>())).ReturnsAsync(new UserConsultingDto());

            var createContactController = new CreateUserController(mockIUserConsultingGateway.Object, mockIUserQueueGateway.Object);

            UserDto dto = new()
            {
                Name = name,
                Email = email,
                DocumentNumber = document
            };

            var result = await createContactController.CreateUserAsync(dto, Presenters.Enum.UserType.Patient, null);

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("usuario teste", "988027555", "teste@teste.com")]
        public async Task When_CreateContact_ShouldBe_Error_WithContactExists(string name, string document, string email)
        {
            var mockIUserQueueGateway = new Mock<IUserQueueGateway>();
            var mockIUserConsultingGateway = new Mock<IUserConsultingGateway>();


            mockIUserConsultingGateway.Setup(s => s.GetUser(It.IsAny<string>())).ReturnsAsync(new UserConsultingDto
            {
                Email = email,
                Id = Guid.NewGuid().ToString(),
                Name = name,
            });

            var createContactController = new CreateUserController(mockIUserConsultingGateway.Object, mockIUserQueueGateway.Object);

            UserDto dto = new()
            {
                Name = name,
                Email = email,
                DocumentNumber = document
            };

            var result = await createContactController.CreateUserAsync(dto, Presenters.Enum.UserType.Doctor, 13253);

            Assert.False(result.Success);
        }

        [Theory]
        [InlineData("usuario teste", "988027555", "teste@teste.com")]
        public async Task When_CreateContact_ShouldBe_Error_ApiConsulting(string name, string document, string email)
        {
            var mockIUserQueueGateway = new Mock<IUserQueueGateway>();
            var mockIUserConsultingGateway = new Mock<IUserConsultingGateway>();

            mockIUserConsultingGateway.Setup(s => s.GetUser(It.IsAny<string>())).ThrowsAsync(new Exception("Falha ao tentar consultar usuário"));

            var createContactController = new CreateUserController(mockIUserConsultingGateway.Object, mockIUserQueueGateway.Object);

            UserDto dto = new()
            {
                Name = name,
                Email = email,
                DocumentNumber = document,
            };            

            await Assert.ThrowsAnyAsync<Exception>(async () => await createContactController.CreateUserAsync(dto,Presenters.Enum.UserType.Doctor, 12345));
        }

        [Theory]
        [InlineData("usuario teste", "40993229808", "")]
        [InlineData("usuario teste", "", "")]
        [InlineData("", "57829013457082349", "teste@teste.com")]
        public async Task When_CreateContact_ShouldBe_Error_WithInvalidDto(string name, string document, string email)
        {
            var mockIUserQueueGateway = new Mock<IUserQueueGateway>();
            var mockIUserConsultingGateway = new Mock<IUserConsultingGateway>();

            mockIUserConsultingGateway.Setup(s => s.GetUser(It.IsAny<string>())).ReturnsAsync(new UserConsultingDto { });

            var createContactController = new CreateUserController(mockIUserConsultingGateway.Object, mockIUserQueueGateway.Object);

            UserDto dto = new()
            {
                Name = name,
                Email = email,
                DocumentNumber= document,
            };

            var result = await createContactController.CreateUserAsync(dto, Presenters.Enum.UserType.Patient, null);

            Assert.False(result.Success);
        }
    }
}