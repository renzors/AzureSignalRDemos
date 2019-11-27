using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo1.Hubs
{
    public class ClientHub : Hub
    {
        static int counter = 0;
        public override Task OnConnectedAsync()
        {
            counter++;
            Clients.All.SendAsync("clientsupdated", counter);
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            counter--;
            Clients.All.SendAsync("clientsupdated", counter);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
