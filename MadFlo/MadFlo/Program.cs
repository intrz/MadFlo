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
            var stringPortType = PortType.Empty.WithValue("string");

            Func<string,string> forwardProcess = (string input) => { return input; };
            var forwardInputPortName = InPortName.Empty.WithValue("input");
            var forwardInputPort = InPort.Empty.WithName(forwardInputPortName).WithPortType(stringPortType).WithProcess(forwardProcess);
            var forwardOutputPortName = OutPortName.Empty.WithValue("out");
            var fordwardOutputPort = OutPort.Empty.WithName(forwardOutputPortName).WithPortType(stringPortType);
            var forwardComponent = ImmComponent.Empty.AddInPort(forwardInputPortName, forwardInputPort)
                                                     .AddOutPort(forwardOutputPortName, fordwardOutputPort);

            Action<string> helloWorldInputPortProcessor = (string x) => Console.WriteLine("Hello {0}", x);
            var helloWorldInputPortName = InPortName.Empty.WithValue("input");
            InPort helloWorldInputPort = InPort.Empty.WithName(helloWorldInputPortName).WithPortType(stringPortType).WithProcess(helloWorldInputPortProcessor);
            var helloWorldComponent = ImmComponent.Empty.AddInPort(helloWorldInputPortName, helloWorldInputPort);

            var myNode = Node.Empty.WithComponent(helloWorldComponent).WithId(NodeId.Empty.WithValue("myNode"));
            var forwardNode = Node.Empty.WithComponent(forwardComponent).WithId(NodeId.Empty.WithValue("forwardNode"));
            var helloGraph = Graph.Empty.AddNode(myNode.Id, myNode)
                                        .AddInitial(Initial.Empty.WithValue("World!").WithToPortName(forwardInputPortName).WithToNodeId(forwardNode.Id))
                                        .AddNode(forwardNode.Id, forwardNode)
                                        .AddEdge(Socket.Empty.WithFromNodeId(forwardNode.Id)
                                                             .WithFromPortName(forwardOutputPortName)
                                                             .WithToNodeId(myNode.Id)
                                                             .WithToPortName(helloWorldInputPortName)
                                        );
                                        

            foreach (var initial in helloGraph.Initials)
            {
                var nodeId = initial.ToNodeId;
                var portName = initial.ToPortName;
                var value = initial.Value;
                var node = helloGraph.Nodes[nodeId];
                var port = node.Component.InPorts[portName];
                port.Process.DynamicInvoke(value);
            }

            Console.Out.Write("jauda");

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
            Console.Write(context.DataFrame.ToString());
            dynamic commandObject = JsonConvert.DeserializeObject(context.DataFrame.ToString());
            List<string> inPorts = new List<string>() { "input1" };
            List<string> outPorts = new List<string>() { "out" };

            switch ((string)commandObject.protocol)
            {
                case "component":
                    switch ((string)commandObject.command)
                    {
                        case "list":
                            Console.WriteLine("list components command");
                            var resp = @"{""protocol"":""component"",""command"":""component"",""payload"":{""name"":""MyTestComponent"",""description"":""Test stuff"",""inPorts"":[{""id"":""input1"",""type"":""all""},{""id"":""input2"",""type"":""all""}],""outPorts"":[{""id"":""out"",""type"":""all""}]}}";
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
                            //var resp = JsonConvert.SerializeObject(response);
                            context.Send(resp);
                            break;
                    }
                    break;
                case "graph":
                    switch ((string)commandObject.command)
                    {
                        case "clear":
                            Console.WriteLine("clear graph command");
                            break;
                    }
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
