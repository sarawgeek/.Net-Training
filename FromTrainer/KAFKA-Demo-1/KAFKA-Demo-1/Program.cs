

using Confluent.Kafka;

string boostrapServer = "localhost:9092";
string topicName = "demo1";

var config = new ProducerConfig
{
    BootstrapServers = boostrapServer
};

using (var producer = new ProducerBuilder<string, string>(config).Build())
{

    var inputtext = Console.ReadLine();
    var messagedelivery = await 
        producer.ProduceAsync(topicName, 
        new Message<string, string> 
        { Key = null, Value = inputtext });


    Console.WriteLine("Message Sent");

}