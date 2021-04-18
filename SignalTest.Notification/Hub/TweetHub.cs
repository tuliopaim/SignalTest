﻿using Microsoft.AspNetCore.SignalR;
using SignalTest.Notification.Interfaces;

namespace SignalTest.Notification.Hub
{
    public class TweetHub : Hub<ITweetHub>
    {
    }
}