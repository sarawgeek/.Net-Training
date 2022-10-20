

using Confluent.Kafka;

public class Program
{

    public static void ListenConumer(string brokerName, string TopicName, CancellationToken cancellationToken)
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = brokerName,
           // GroupId = "MyGroup1",
            AutoOffsetReset = AutoOffsetReset.Latest

        };

        using(var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
        {

            consumer.Subscribe(TopicName);

            while (true)
            {
                try
                {
                    var consumerResult = consumer.Consume(cancellationToken);
                    if(consumerResult.Message != null)
                    {
                        Console.WriteLine($"Message is {consumerResult.Message.Value}  ");
                    }


                }catch(Exception ex)
                {
                    Console.WriteLine(ex);
                    consumer.Close();
                }
            }

        }
    }



    public static void Main(string[] args)
    {
        string boostrapServer = "localhost:9092";
        string topicName = "demo1";


        CancellationTokenSource cts = new CancellationTokenSource();
        Console.CancelKeyPress += (_, e) => {
            e.Cancel = true; // prevent the process from terminating.
            cts.Cancel();
        };

        ListenConumer(boostrapServer, topicName, cts.Token);
    }
}