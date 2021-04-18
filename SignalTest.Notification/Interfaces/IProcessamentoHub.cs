using System;
using System.Threading.Tasks;

namespace SignalTest.Infra.Notification.Interfaces
{
    public interface IProcessamentoHub
    {
        Task NotificarProcessamento(Guid userId, string item, decimal percentual);
    }
}