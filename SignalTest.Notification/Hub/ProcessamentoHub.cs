using Microsoft.AspNetCore.SignalR;
using SignalTest.Infra.Notification.Interfaces;

namespace SignalTest.Infra.Notification.Hub
{
    public class ProcessamentoHub : Hub<IProcessamentoHub>
    {
    }
}