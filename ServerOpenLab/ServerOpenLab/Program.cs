using System;
using System.Net;
using System.Net.Sockets;
using System.Security.Principal;
using System.Text;
using System.Threading;


namespace TcpServerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = null;


            try
            {
                // Set the TCP listener to listen on any IP address and port 5001
                server = new TcpListener(IPAddress.Any, 5001);


                // Start the server
                server.Start();
                Console.WriteLine("Server started. Waiting for connections...");


                // Run the server in a loop to accept multiple clients
                while (true)
                {
                    // Accept a client connection
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Client connected.");


                    // Handle the client in a separate thread
                    Thread clientThread = new Thread(HandleClient);
                    clientThread.Start(client);
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine("SocketException: {0}", ex.Message);
            }
            finally
            {
                // Stop the server and free the port
                server?.Stop();
            }
        }


        // Method to handle communication with a connected client
        private static void HandleClient(object clientObj)
        {
            TcpClient client = (TcpClient)clientObj;


            //creare random date
            // string RandomData()
            // {
            //     Random random = new Random();
            //     ulong data = random.Next(0000000000000000000, 9999999999999999999);


            //     return $"{data}";
            // }




            try
            {
                // Get the network stream for reading and writing
                NetworkStream stream = client.GetStream();


                // Send a welcome message to the client




                // Keep the connection open to continuously send data
                while (true)
                {
                    // string NGdata = RandomData();
                    long data = 00200001000000000000;




                    byte[] dataResult = Encoding.UTF8.GetBytes(data.ToString());
                    // string message = "Hello from the server! Please enter a message to send to the client.";
                    // byte[] data = Encoding.UTF8.GetBytes(message);
                    stream.Write(dataResult, 0, dataResult.Length);
                    Console.WriteLine("Sent Result : " + data);
                    Console.WriteLine("Time" + DateTime.Now);
                    // Console.WriteLine("NG : " + NGdata + " AG : " + AGdata);
                    // Console.WriteLine("Time" + DateTime.Now);


                    // Sleep for a specified interval before sending the next message
                    Thread.Sleep(5000); // 5 seconds interval
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
            finally
            {
                // Ensure the client connection is closed
                client.Close();
            }
        }
    }
}
