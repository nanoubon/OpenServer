using System;
using System.Net.Sockets;
using System.Text;


namespace TcpClientExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Connect to the server
                TcpClient client = new TcpClient("127.0.0.1", 5001);
                NetworkStream stream = client.GetStream();


                // Continuously read server responses
                byte[] data = new byte[256];
                int bytes;


                while ((bytes = stream.Read(data, 0, data.Length)) != 0)
                {
                    string response = Encoding.UTF8.GetString(data, 0, bytes);
                    Console.WriteLine("Received: {0}", response);
                    Console.WriteLine("Time" + DateTime.Now);
                }


                // Close the client connection
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }
    }
}
