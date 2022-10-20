using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;

namespace Kafka_Web_Api_Consumer.Controllers
{
    public class KafkaConsumer : Controller
    {
        string groupId = "myGroup1";
        string bootstrapServer = "localhost:9094";
        string topic = "logistics";

        public IActionResult Index()
        {
            return View();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var config = new ConsumerConfig
            {
                GroupId = groupId,
                BootstrapServers = bootstrapServer,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using(var consumerBuilder =  new ConsumerBuilder<Ignore, string>(config).Build())
            {
                consumerBuilder.Subscribe(topic);
                var cancelToken =  new CancellationTokenSource();

                try
                {
                    while(true)
                    {
                        var consumer = consumerBuilder.Consume(cancelToken.Token);
                        if (consumer.Message != null)
                        {
                            Console.WriteLine($"Message is {}"consumer.Message);
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
