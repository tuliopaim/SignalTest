using Microsoft.AspNetCore.SignalR;
using SignalTest.Infra.Notification.Interfaces;

namespace SignalTest.Infra.Notification.Hubs
{
    public class ProcessamentoHub : Hub<IProcessamentoHub>
    {
    }
}