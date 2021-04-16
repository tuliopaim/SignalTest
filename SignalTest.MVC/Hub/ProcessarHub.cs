using Microsoft.AspNetCore.SignalR;
using SignalTest.MVC.Domain.Interfaces;

namespace SignalTest.MVC.Hub
{
    public class ProcessarHub : Microsoft.AspNetCore.SignalR.Hub
    {
        private readonly IProcessService _service;

        public ProcessarHub(IProcessService service)
        {
            _service = service;
        }

        public void Processar()
        {
            _service.Processar(Context.UserIdentifier);
        }
    }
}