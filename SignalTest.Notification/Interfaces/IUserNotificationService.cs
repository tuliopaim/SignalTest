using System.Threading.Tasks;

namespace SignalTest.Notification.Interfaces
{
    public interface IUserNotificationService
    {
        Task NotificarUsuarioOnline(string usuario);
    }
}