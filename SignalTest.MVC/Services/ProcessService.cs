using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalTest.MVC.Domain.Interfaces;
using SignalTest.MVC.Hub;

namespace SignalTest.MVC.Services
{
    public class ProcessService : IProcessService
    {
        private readonly IHubContext<ProcessarHub> _hub;

        public ProcessService(IHubContext<ProcessarHub> hub)
        {
            _hub = hub;
        }

        public async Task Processar(string id)
        {
            for (var i = 0; i < 10; i++)
            {
                await Task.Delay(2000);

                var itemProcessado = $"Item {i} processado...";

                await _hub.Clients.User(id)
                    .SendAsync("ReportProcessamento", itemProcessado, i * 10);
            }
        }
    }
}