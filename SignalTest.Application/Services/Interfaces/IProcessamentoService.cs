using System;
using System.Threading.Tasks;

namespace SignalTest.Application.Services.Interfaces
{
    public interface IProcessamentoService
    {
        Task Processar(Guid id);
    }
}