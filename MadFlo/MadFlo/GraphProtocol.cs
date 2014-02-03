using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadFlo
{
    public static class GraphProtocol
    {
        public static Func<GraphId, GraphName, Graph> Clear = (id, name) =>
        {
            return Graph.Empty.WithId(id).WithName(name);
        };

        public static Func<Node, Graph, Graph> AddNode = (node, graph) =>
        {
            return null;// graph.AddNode(node);
        };

        public static void Initialize()
        {
            //Start network component
            //input: currentGraphState, IdOfNodeToExecute, componentToExecute
            var graphPortType = PortType.Empty.WithValue("graph");
            var graphStateInputName = InPortName.Empty.WithValue("currentGraphState");
            var idOfNodeToExecuteInputName = InPortName.Empty.WithValue("nodeId");
            var componentToExecuteInputName = InPortName.Empty.WithValue("component");
            var networkOutputName = OutPortName.Empty.WithValue("out");
            var networkOutPort = OutPort.Empty.WithName(networkOutputName).WithPortType(graphPortType);

            Func<object, Graph, NodeId, ImmComponent, Graph> graphStateProcess = (object input, Graph graph, NodeId nodeId, ImmComponent component) =>
            {
                /*var currentGraphState = graph;
                foreach (var initial in input.graph)
                {
                    var currentNodeId = initial.ToNodeId;
                    var portName = initial.ToPortName;
                    var value = initial.Value;
                    var node = currentGraphState.Nodes[currentNodeId];
                    var port = node.Component.InPorts[portName];
                    currentGraphState = (Graph)port.Process.DynamicInvoke(value, currentGraphState, currentNodeId, node.Component);
                }
                graph.Send(input, nodeId, networkOutputName);*/
                return graph;
            };
            var networkInputPort = InPort.Empty.WithName(graphStateInputName).WithPortType(graphPortType).WithProcess(graphStateProcess);

           
        }
    }
}
