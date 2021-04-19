using System.Threading.Tasks;

namespace SignalTest.Infra.Notification.Interfaces
{
    public interface IProcessamentoHub
    {
        Task ResultadoProcessamento(string item, decimal percentual);
    }
}