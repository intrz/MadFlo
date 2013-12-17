using Alchemy;
using Alchemy.Classes;
using Mono.CSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MadFlo
{
    class Program
    {
        private static Evaluator evaluator = new Evaluator(new CompilerContext(new CompilerSettings(), new ConsoleReportPrinter()));

        static void Main(string[] args)
        {
            var aServer = new WebSocketServer(3569, IPAddress.Any)
            {
                OnReceive = OnReceive,
                OnSend = OnSend,
                OnConnected = OnConnect,
                OnDisconnect = OnDisconnect,
                TimeOut = new TimeSpan(0, 5, 0)
            };

            aServer.Start();

            // Accept commands on the console and keep it alive
            var command = string.Empty;
            while (command != "exit")
            {
                command = Console.ReadLine();
            }

            aServer.Stop();
        }

        public static void OnConnect(UserContext context)
        {
            Console.WriteLine("Client Connection From : " + context.ClientAddress);
        }

        public static void OnReceive(UserContext context)
        {
            Console.WriteLine("Received Data From :" + context.ClientAddress);
            
            try
            {
                var json = context.DataFrame.ToString();

                dynamic obj = JsonConvert.DeserializeObject(json);

                switch ((string)obj.protocol)
                {
                    case "command":                        
                        break;
                    case "graph":
                        break;
                    case "network":
                        break;
                }
            }
            catch (Exception e)
            {
                context.Send(JsonConvert.SerializeObject("Error" + e.ToString()));
            }
        }

        public static void OnSend(UserContext context)
        {
            Console.WriteLine("Data Send To : " + context.ClientAddress);
        }

        public static void OnDisconnect(UserContext context)
        {
            Console.WriteLine("Client Disconnected : " + context.ClientAddress);
        }
    }
}
