// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using System.Text;

Console.WriteLine("Hello, World!");


var factory = new ConnectionFactory()
{
    HostName = "localhost",
    Port = 5673,
    UserName = "admin",
    Password = "admin",
    VirtualHost = "/"
};
try
{
    //Đầu tiên ta tạo mới một connection tới RabbitMQ với username, password và host name.
    var connection = factory.CreateConnection();
    var model = connection.CreateModel();

    //Console.WriteLine("Creating Exchange");
    ////Để tạo mới 1 exchange ta dùng hàm ExchangeDeclare với 2 params là exchange name và           exchange type
    //model.ExchangeDeclare("demoExchange", ExchangeType.Direct);


    // Create Queue
    //model.QueueDeclare("demoqueue", true, false, false, null);
    //Console.WriteLine("Creating Queue");

    //// Bind Queue to Exchange
    //model.QueueBind("demoqueue", "demoExchange", "directexchange_key");

    //Console.WriteLine("Creating Binding");

    var properties = model.CreateBasicProperties();
    properties.Persistent = false;

    byte[] messagebuffer = Encoding.Default.GetBytes("Direct Message");
    model.BasicPublish("demoExchange", "directexchange_key", properties, messagebuffer);
    Console.WriteLine("Message Sent");

    Console.ReadLine();
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
Console.ReadLine();