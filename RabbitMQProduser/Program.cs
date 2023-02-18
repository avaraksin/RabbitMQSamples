using RabbitMQ.Client;
using System;
using System.Text;

namespace RabbitMQProduser
{
	internal class Program
	{
		static void Main()
		{
			using (var connection = GetRabbitConnection())
			using (var channel = connection.CreateModel())
			{
				for (int i = 0; i < 1; i++)
				{
					string message = DateTime.UtcNow.ToString();

					var body = Encoding.UTF8.GetBytes(message);

					channel.BasicPublish(exchange: "",
										 routingKey: "Notification",
										 basicProperties: null,
										 body: body);
					
					Console.WriteLine($"Отправлено {message}");
				}
			}

			Console.WriteLine(" Press [enter] to exit.");
			Console.ReadLine();
		}

		static private IConnection GetRabbitConnection()
		{
			ConnectionFactory factory = new ConnectionFactory
			{
				UserName = "kquhcgmb",
				Password = "4oVomTv1D4Hfeqiqp_C1c6kPQdJu4kzJ",
				VirtualHost = "kquhcgmb",
				HostName = "mustang.rmq.cloudamqp.com"
            };
			IConnection conn = factory.CreateConnection();
			return conn;
		}
	}
}