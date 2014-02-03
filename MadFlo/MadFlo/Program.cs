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
            var intPortType = PortType.Empty.WithValue("int");

            //Start adder component
            var adderOutputName = OutPortName.Empty.WithValue("out");
            var adderOutputPort = OutPort.Empty.WithName(adderOutputName).WithPortType(intPortType);

            Func<int, Graph, NodeId, ImmComponent, Graph> addFirstNum = (int x, Graph graph, NodeId nodeId, ImmComponent component) => 
            {
                if (component.Properties.ContainsKey("y"))
                {
                    int y = (int)component.Properties["y"];
                    var result = x + y;
                    graph.Send(result, nodeId, adderOutputName);
                    return graph;
                }
                else
                {
                    component = component.WithProperties(component.Properties.Add("x", x));
                    return graph.ReplaceNode(nodeId, Node.Empty.WithComponent(component).WithId(nodeId));
                }
            };

            Func<int, Graph, NodeId, ImmComponent, Graph> addSecondNum = (int y, Graph graph, NodeId nodeId, ImmComponent component) => 
            {
                if (component.Properties.ContainsKey("x"))
                {
                    int x = (int)component.Properties["x"];
                    var result = x + y;
                    graph.Send(result, nodeId, adderOutputName);
                    return graph;
                }
                else
                {
                    component = component.WithProperties(component.Properties.Add("y", y));
                    return graph.ReplaceNode(nodeId, Node.Empty.WithComponent(component).WithId(nodeId));
                }
            };
            var adderInputPortName1 = InPortName.Empty.WithValue("in1");
            var adderInputPortName2 = InPortName.Empty.WithValue("in2");
            InPort adderInputPort1 = InPort.Empty.WithName(adderInputPortName1).WithPortType(intPortType).WithProcess(addFirstNum);
            InPort adderInputPort2 = InPort.Empty.WithName(adderInputPortName2).WithPortType(intPortType).WithProcess(addSecondNum);
            var adderComponent = ImmComponent.Empty.AddInPort(adderInputPortName1, adderInputPort1)
                                                   .AddInPort(adderInputPortName2, adderInputPort2);
            //End adder component


            //Start forwarder component
            var forwardOutputPortName = OutPortName.Empty.WithValue("out");
            var fordwardOutputPort = OutPort.Empty.WithName(forwardOutputPortName).WithPortType(stringPortType);
            Func<string, Graph, NodeId, ImmComponent, ImmComponent> forwardProcess = (string input, Graph graph, NodeId nodeId, ImmComponent component) => 
            { 
                graph.Send(input, nodeId, forwardOutputPortName);
                return component;
            };
            var forwardInputPortName = InPortName.Empty.WithValue("in");
            var forwardInputPort = InPort.Empty.WithName(forwardInputPortName).WithPortType(stringPortType).WithProcess(forwardProcess);                        
            var forwardComponent = ImmComponent.Empty.AddInPort(forwardInputPortName, forwardInputPort)
                                                     .AddOutPort(forwardOutputPortName, fordwardOutputPort);
            //End forwarder component


            //Start console writer component
            Func<object, Graph, NodeId, ImmComponent, Graph> helloWorldInputPortProcessor = (object x, Graph graph, NodeId nodeId, ImmComponent component) =>
            {
                Console.WriteLine("Hello {0}", x.ToString());
                return graph;
            };
            var consoleWriterInputPortName = InPortName.Empty.WithValue("in");
            InPort helloWorldInputPort = InPort.Empty.WithName(consoleWriterInputPortName).WithPortType(stringPortType).WithProcess(helloWorldInputPortProcessor);
            var consoleWriterComponent = ImmComponent.Empty.AddInPort(consoleWriterInputPortName, helloWorldInputPort);
            //End console writer component


            var consoleWriterNode = Node.Empty.WithComponent(consoleWriterComponent).WithId(NodeId.Empty.WithValue("myNode"));
            var forwardNode = Node.Empty.WithComponent(forwardComponent).WithId(NodeId.Empty.WithValue("forwardNode"));
            var adderNode = Node.Empty.WithComponent(adderComponent).WithId(NodeId.Empty.WithValue("adder"));
            /*var helloGraph = Graph.Empty.AddNode(myNode.Id, myNode)
                                        .AddInitial(Initial.Empty.WithValue("World!").WithToPortName(forwardInputPortName).WithToNodeId(forwardNode.Id))
                                        .AddNode(forwardNode.Id, forwardNode)
                                        .AddEdge(Socket.Empty.WithFromNodeId(forwardNode.Id)
                                                             .WithFromPortName(forwardOutputPortName)
                                                             .WithToNodeId(myNode.Id)
                                                             .WithToPortName(helloWorldInputPortName)
                                        );
             */

            var runGraphGraph = Graph.Empty
                                ;

            var helloGraph = Graph.Empty
                            .AddNode(adderNode.Id, adderNode)
                            .AddInitial(Initial.Empty.WithValue(1).WithToPortName(adderInputPortName1).WithToNodeId(adderNode.Id))
                            .AddInitial(Initial.Empty.WithValue(4).WithToPortName(adderInputPortName2).WithToNodeId(adderNode.Id))
                            .AddNode(consoleWriterNode.Id, consoleWriterNode)
                            .AddEdge(Socket.Empty.WithFromNodeId(adderNode.Id)
                                                 .WithFromPortName(adderOutputName)
                                                 .WithToNodeId(consoleWriterNode.Id)
                                                 .WithToPortName(consoleWriterInputPortName)
                            );
                                        

            var currentGraph = helloGraph;
            foreach (var initial in helloGraph.Initials)
            {
                var nodeId = initial.ToNodeId;
                var portName = initial.ToPortName;
                var value = initial.Value;
                var node = currentGraph.Nodes[nodeId];
                var port = node.Component.InPorts[portName];
                currentGraph = (Graph)port.Process.DynamicInvoke(value, currentGraph, nodeId, node.Component);
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
