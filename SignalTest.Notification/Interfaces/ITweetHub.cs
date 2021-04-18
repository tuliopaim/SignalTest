using System.Threading.Tasks;

namespace SignalTest.Notification.Interfaces
{
    public interface ITweetHub
    {
        Task NovoTweet(string mensagem);
    }
}