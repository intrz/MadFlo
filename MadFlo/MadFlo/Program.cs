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
            string testReturn = @"{""protocol"":""component"",""command"":""component"",""payload"":{""name"":""ToggleBoolean"",""description"":""Invert output packet everytime an input packet arrives. Output defaults to false"",""inPorts"":[{""id"":""in"",""type"":""all""},{""id"":""reset"",""type"":""all""}],""outPorts"":[{""id"":""out"",""type"":""all""}]}}";

            //Console.WriteLine("Received Data From :" + context.ClientAddress);
            //{"protocol":"graph","command":"addnode","payload":{"id":"ToggleBoolean_u3bip","component":"ToggleBoolean","metadata":{"x":200,"y":200,"label":"ToggleBoolean"}}}
            Console.Write(context.DataFrame.ToString());
            dynamic commandObject = JsonConvert.DeserializeObject(context.DataFrame.ToString());
            List<string> inPorts = new List<string>() { "input1" };
            List<string> outPorts = new List<string>() { "out" };

            switch ((string)commandObject.protocol)
            {
                case "component":
                    switch ((string)commandObject.protocol)
                    {
                        case "list":
                            dynamic response = new
                            {
                                protocol = "component",
                                command = "component",
                                payload = new
                                {
                                    name = "name",
                                    description = "test",
                                    inPorts = inPorts,
                                    outPorts = outPorts
                                }
                            };
                            var resp = JsonConvert.SerializeObject(response);
                            context.Send(testReturn);
                            break;
                    }
                    break;
                case "graph":
                    break;
                case "network":
                    break;
                default:
                    break;
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
