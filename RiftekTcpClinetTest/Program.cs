using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SocketTcpClient
{
    class Program
    {
        private const int port = 56000;
        private const string server = "192.168.1.30";

        static void Main(string[] args)
        {
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(server, port);

                byte[] data = new byte[32];
                Array.Fill<byte>(data, 5);
                //data[2] = 7;
                //StringBuilder response = new StringBuilder();
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
                Console.Read();
                //do
                //{
                //    int bytes = stream.Read(data, 0, data.Length);
                //    response.Append(Encoding.UTF8.GetString(data, 0, bytes));
                //}
                //while (stream.DataAvailable); // пока данные есть в потоке

                //Console.WriteLine(response.ToString());

                // Закрываем потоки
                stream.Close();
                client.Close();
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
            }

            Console.WriteLine("Запрос завершен...");
            Console.Read();
        }
    }
}
