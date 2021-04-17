using System.Threading.Tasks;

namespace SignalTest.MVC.Domain.Interfaces
{
    public interface IProcessService
    {
        Task Processar(string id);
    }
}