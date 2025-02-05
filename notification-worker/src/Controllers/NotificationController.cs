using Presenters;
using Interfaces;

namespace Controllers
{
    public class NotificationController(
        INotificationDbGateway dbGateway,
        INotificationUseCase useCase,
        IEmailGateway emailGateway) : INotificationController
    {
        public async Task NotificationAsync(CreatedAppointmentDto dto)
        {
            var result = useCase.Notification(dto);

            if (result.Errors.Count > 0)
                throw new Exception(result.Errors[0]);

            var emailResult = await emailGateway.NotificationAsync(dto);

            var createEntity = useCase.CreateEntity(emailResult, dto.Id);

            await dbGateway.AddAsync(createEntity.Data);
            await dbGateway.CommitAsync();
        }
    }
}