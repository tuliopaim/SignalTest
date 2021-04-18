using System;
using System.Threading.Tasks;

namespace SignalTest.Domain.Interfaces.Notification
{
    public interface IProcessoNotificationService
    {
        Task NotificarProcessamento(Guid userId, string itemProcessado, decimal percentual);
    }
}