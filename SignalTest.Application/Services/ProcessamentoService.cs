using System;
using System.Threading.Tasks;
using SignalTest.Application.Services.Interfaces;
using SignalTest.Domain.Interfaces.Notification;

namespace SignalTest.Application.Services
{
    public class ProcessamentoService : IProcessamentoService
    {
        private readonly IProcessoNotificationService _notification;

        public ProcessamentoService(IProcessoNotificationService notification)
        {
            _notification = notification;
        }

        public async Task Processar(Guid id)
        {
            for (var i = 1; i <= 10; i++)
            {
                await Task.Delay(1000);

                var itemProcessado = $"Item {i} processado...";

                await _notification.NotificarProcessamento(id, itemProcessado, i * 10);
            }
        }
    }
}