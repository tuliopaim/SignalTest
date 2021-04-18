using System.Threading.Tasks;

namespace SignalTest.Infra.Notification.Interfaces
{
    public interface IUserHub
    {
        Task UsuarioOnline(string usuario);
    }
}