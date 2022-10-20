    using Confluent.Kafka;

    string bootstrapServer = "localhost:9094";
    string topicName = "logistics";

    var config = new ProducerConfig
    {
         BootstrapServers = bootstrapServer
    };

    using (var producer = new ProducerBuilder<string, string>(config).Build())
    {
        var inputText = Console.ReadLine();
        var messageDelivery = await producer.ProduceAsync(topicName,new Message<string, string> { Key = null, Value = inputText });

        Console.WriteLine("Message Sent");
    }