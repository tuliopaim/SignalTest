using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalTest.MVC.Domain.Interfaces;

namespace SignalTest.MVC.Hub
{
    public class ChatHub : Microsoft.AspNetCore.SignalR.Hub
    {
        private readonly IUserInstanceService _service;

        public ChatHub(IUserInstanceService service)
        {
            _service = service;
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}