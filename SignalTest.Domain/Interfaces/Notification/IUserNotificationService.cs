using System.Threading.Tasks;

namespace SignalTest.Domain.Interfaces.Notification
{
    public interface IUserNotificationService
    {
        Task NotificarUsuariosOnline(string usuario);
    }
}