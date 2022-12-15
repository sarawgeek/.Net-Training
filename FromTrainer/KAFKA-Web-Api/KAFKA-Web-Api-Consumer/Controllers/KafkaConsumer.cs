using Confluent.Kafka;
using System.Text.Json;

namespace KAFKA_Web_Api_Consumer.Controllers
{
    public class KafkaConsumer : IHostedService
    {

        private readonly string topic = "products";
        private readonly string groupId = "mygroup22";
        private readonly string bootstrapServers = "localhost:9092";

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var config = new ConsumerConfig
            {
                GroupId = groupId,
                BootstrapServers = bootstrapServers,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };


            using (var consumerBuilder = new ConsumerBuilder<Ignore, string>(config).Build())
            {
                consumerBuilder.Subscribe(topic);
                var cancelToken = new CancellationTokenSource();

                try
                {
                    while (true)
                    {
                        var consumer = consumerBuilder.Consume(cancelToken.Token);
                        if (consumer.Message != null)
                        {
                            Console.WriteLine($"Message is {consumer.Message.Value}  ");

                            var Product = JsonSerializer.Deserialize<Product>(consumer.Message.Value);

                            Console.WriteLine($"Product Details are {Product.ProductId} {Product.ProductName} {Product.ProductPrice}");

                        }

                    }
                }
                catch (OperationCanceledException)
                {
                    consumerBuilder.Close();
                }
            }


            return Task.CompletedTask;

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
