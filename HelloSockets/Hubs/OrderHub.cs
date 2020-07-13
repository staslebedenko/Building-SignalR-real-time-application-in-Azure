using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace HelloSockets
{
    public class OrderHub : Hub
    {
        private readonly OrderChecker _orderChecker;

        public OrderHub(OrderChecker orderChecker)
        {
            _orderChecker = orderChecker;
        }

        public async Task GetUpdateForOrder(Guid orderId)
        {
            CheckResult result;
            do
            {
                result = _orderChecker.GetUpdate(orderId);
                Thread.Sleep(1000);
                if (result.New)
                    await Clients.Caller.SendAsync("ReceiveOrderUpdate",
                        result.Update);
            } while (!result.Finished);
            await Clients.Caller.SendAsync("Finished");
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}