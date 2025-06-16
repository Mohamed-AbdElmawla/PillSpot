using AutoMapper;
using Service.Contracts;
using Service.Contracts.Notifications.Commands;
using Shared.DataTransferObjects;
using System.Threading.Tasks;

namespace Service.Notifications.Commands
{
    public class CreateNotificationCommandHandler
    {
        private readonly INotificationService _notificationService;
        private readonly IRealTimeNotificationService _realTimeNotificationService;
        private readonly IMapper _mapper;

        public CreateNotificationCommandHandler(
            INotificationService notificationService,
            IRealTimeNotificationService realTimeNotificationService,
            IMapper mapper)
        {
            _notificationService = notificationService;
            _realTimeNotificationService = realTimeNotificationService;
            _mapper = mapper;
        }

        public async Task<NotificationDto> HandleAsync(CreateNotificationCommand command)
        {
            var notificationDto = new NotificationForCreationDto
            {
                UserId = command.UserId,
                ActorId = command.ActorId,
                Message = command.Message,
                Type = command.Type,
                RelatedEntityId = command.RelatedEntityId,
                RelatedEntityType = command.RelatedEntityType
            };
            var notification = await _notificationService.CreateNotificationAsync(notificationDto);
            var notificationDtoMapper = _mapper.Map<NotificationDto>(notification);
            await _realTimeNotificationService.SendNotificationAsync(command.UserId, notificationDtoMapper);
            return notificationDtoMapper;
        }
    }
} 