using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadFlo
{
    public sealed class Node
    {
        public NodeId Id { get; private set; }
        public Component Component { get; private set; }

        public Node()
        {
            Id = NodeId.Empty;
            Component = Component.Empty;
        }

        private readonly static Node _empty = new Node();
        public static Node Empty { get { return _empty; } }

        public bool IsEmpty()
        {
            return this == Empty;
        }


        public Node GetEmpty()
        {
            return Empty;
        }


        private Node Clone()
        {
            var c = new Node();
            c.Id = this.Id;
            c.Name = this.Name;
            return c;
        }

        public Node WithName(NodeName value)
        {
            var c = this.Clone();
            c.Name = value;
            return c;
        }

        public Node WithId(NodeId value)
        {
            var c = this.Clone();
            c.Id = value;
            return c;
        }

    }

/*            function Node(name) {
      this.name = name != null ? name : '';
      this.properties = {};
      this.nodes = [];
      this.edges = [];
      this.initializers = [];
      this.exports = [];
      this.groups = [];
    }
        */
    
}
