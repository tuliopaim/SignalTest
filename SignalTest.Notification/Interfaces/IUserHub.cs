using System.Threading.Tasks;

namespace SignalTest.Notification.Interfaces
{
    public interface IUserHub
    {
        Task UsuarioOnline(string usuario);
    }
}