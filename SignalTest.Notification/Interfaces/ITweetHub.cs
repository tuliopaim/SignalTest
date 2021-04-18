using System.Threading.Tasks;

namespace SignalTest.Infra.Notification.Interfaces
{
    public interface ITweetHub
    {
        Task NovoTweet(string mensagem);
    }
}