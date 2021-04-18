using System;
using System.Threading.Tasks;

namespace SignalTest.Notification.Interfaces
{
    public interface IProcessoNotificationService
    {
        Task NotificarProcessamento(Guid userId, string itemProcessado, decimal percentual);
    }
}