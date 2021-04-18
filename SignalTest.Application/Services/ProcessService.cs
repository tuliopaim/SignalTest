using System;
using System.Threading.Tasks;
using SignalTest.Application.Services.Interfaces;
using SignalTest.Domain.Interfaces.Notification;

namespace SignalTest.Application.Services
{
    public class ProcessService : IProcessService
    {
        private readonly IProcessoNotificationService _notification;

        public ProcessService(IProcessoNotificationService notification)
        {
            _notification = notification;
        }

        public async Task Processar(Guid id)
        {
            for (var i = 0; i <= 10; i++)
            {
                await Task.Delay(2000);

                var itemProcessado = $"Item {i} processado...";

                await _notification.NotificarProcessamento(id, itemProcessado, i * 10);
            }
        }
    }
}