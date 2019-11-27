using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPoll.Hubs
{
    public class PollHub : Hub
    {
        static int conpina = 0;
        static int sinpina = 0;
        static int ambos = 0;

        public async Task SetVote(int tipo)
        {
            switch (tipo)
            {
                case 1:
                    conpina++;
                    break;
                case 2:
                    sinpina++;
                    break;
                case 3:
                    ambos++;
                    break;
            }
            
            await Clients.All.SendAsync("updatePoll", conpina, sinpina, ambos);
        }
        public override Task OnConnectedAsync()
        {
            Clients.Client(Context.ConnectionId).SendAsync("updatePoll", conpina, sinpina, ambos);
            return base.OnConnectedAsync();
        }
    }
}
