using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using TimerTriggers.Services;

namespace TimerTriggers
{
    public class Function1
    {
        private readonly ILogger _logger;
        private readonly IQueueService _queueService;
        public Function1(ILoggerFactory loggerFactory, IQueueService queueService)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
            _queueService = queueService;
        }

        //[Function("Function1")]
        //public async Task Run([TimerTrigger("*/2 * * * * *")] TimerInfo myTimer)
        //{
        //    await _queueService.SendMessageAsync(Guid.NewGuid().ToString());
        //    _logger.LogInformation($"Message go: {DateTime.Now}");
            
        //    if (myTimer.ScheduleStatus is not null)
        //    {
        //        //_logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
        //    }
        //}

        [Function("Function2")]
        public async Task Run2([TimerTrigger("*/6 * * * * *")] TimerInfo myTimer)
        {
            await _queueService.ReceiveMessageWithCountAsync(3);
            _logger.LogInformation($"Message Delete: {DateTime.Now}");

            if (myTimer.ScheduleStatus is not null)
            {
                //_logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
        }

    }
}
