using System;
using System.Threading.Tasks;

namespace SignalTest.Notification.Interfaces
{
    public interface IProcessoHub
    {
        Task NotificarProcessamento(Guid userId, string item, decimal percentual);
    }
}