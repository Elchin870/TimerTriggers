using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerTriggers.Services
{
    public interface IQueueService
    {
        Task SendMessageAsync(string message);
        Task SendMessageWithCountAsync(string message, int count);
        Task<string> ReceiveMessageAsync();
        Task<string> ReceiveMessageWithCountAsync(int count);

    }
}
