using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace KAFKA_Web_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        string boostrapServer = "localhost:9092";
        string topicName = "products";

        public ProductController()
        {

        }

        [HttpPost]
        public async Task<string> Create([FromBody]Product product)
        {

            var config = new ProducerConfig
            {
                BootstrapServers = boostrapServer
            };

            using (var producer = new ProducerBuilder<string, string>(config).Build())
            {

                string inputtext = JsonSerializer.Serialize(product);
                var messagedelivery = await  producer.ProduceAsync(topicName,new Message<string, string>{ Key = null, Value = inputtext });
                Console.WriteLine("Message Sent " + inputtext);
            }

            return await Task.FromResult("Product Topic Sent");
        }
    }
}
