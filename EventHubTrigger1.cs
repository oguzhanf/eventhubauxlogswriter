using System;
using Azure.Messaging.EventHubs;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace eventnamespace
{
    public class EventHubTrigger1
    {
        private readonly ILogger<EventHubTrigger1> _logger;

        public EventHubTrigger1(ILogger<EventHubTrigger1> logger)
        {
            _logger = logger;
        }

        [Function(nameof(EventHubTrigger1))]
        public void Run([EventHubTrigger("insights-logs-advancedhunting-devicefileevents", Connection = "premiumdefenderhub_RootManageSharedAccessKey_EVENTHUB")] EventData[] events)
        {
            foreach (EventData @event in events)
            {
                _logger.LogInformation("Event Body: {body}", @event.Body);
                _logger.LogInformation("Event Content-Type: {contentType}", @event.ContentType);
            }
        }
    }
}
