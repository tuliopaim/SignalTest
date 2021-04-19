using System;
using System.Threading.Tasks;

namespace SignalTest.Domain.Interfaces.Services
{
    public interface IProcessamentoService
    {
        Task Processar(Guid id);
    }
}