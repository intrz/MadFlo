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
    }
}
