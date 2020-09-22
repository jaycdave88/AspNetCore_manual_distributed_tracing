using Datadog.Trace;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Synchronus_Server_Socket
{
    public class SynchronousSocketListener
    {

        // Incoming data from the client.  
        public static string data = null;

        public static void StartListening()
        {

            // Data buffer for incoming data.  
            byte[] bytes = new Byte[1024];

            // Establish the local endpoint for the socket.  
            // Dns.GetHostName returns the name of the
            // host running the application.  
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP socket.  
            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and
            // listen for incoming connections.  
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                // Start listening for connections.  
                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");
                    // Program is suspended while waiting for an incoming connection.  
                    Socket handler = listener.Accept();

                    data = null;

                    // An incoming connection needs to be processed.  
                    while (true)
                    {
                        int bytesRec = handler.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRec);

                        if (data.IndexOf("<EOF>") > -1)
                        {
                            break;
                        }
                    }
                    var eof = data.IndexOf("<EOF>");
                    var strings = data.Substring(0, eof).Split(',');


                    ulong traceId = ulong.Parse(strings[0]);
                    ulong spanId = ulong.Parse(strings[1]);
                    var samplingPriority = (SamplingPriority)int.Parse(strings[2]);

                    // Show the data on the console.  
                    Console.WriteLine($"TraceID={traceId}, SpanID={spanId}, samplingPriority={samplingPriority}");

                    //creating the SpanContext to use the parameters from the distributed trace
                    var context = new SpanContext(traceId, spanId, samplingPriority);

                    //StartActive param is OperationName
                    using (var scope = Tracer.Instance.StartActive("SynchronousSocketListener.StartListening", context))
                    {

                        var span = scope.Span;
                        span.Type = "custom";
                        span.ResourceName = "StartListening";

                        // Echo the data back to the client.  
                        byte[] msg = Encoding.ASCII.GetBytes(data);

                        handler.Send(msg);
                        handler.Shutdown(SocketShutdown.Both);
                        handler.Close();
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();



        }

        public static int Main(String[] args)
        {
            StartListening();
            return 0;
        }
    }
}
