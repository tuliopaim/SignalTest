using System;
using System.Threading.Tasks;

namespace SignalTest.Application.Services.Interfaces
{
    public interface IProcessService
    {
        Task Processar(Guid id);
    }
}