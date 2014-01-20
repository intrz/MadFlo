using MadFlo;
using System;
using System.Linq;

namespace MadFlo
{
    public sealed class Node
    {
        public NodeId Id { get;  private set; }
        public ImmComponent Component { get;  private set; }

        public Node()
        {
            Id = NodeId.Empty;
            Component = ImmComponent.Empty;
        }

        private readonly static Node _empty = new Node();
        public static Node Empty { get { return _empty; }   }

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
            c.Component = this.Component;
            return c;
        }

        // -----------------------
        // Id
        // -----------------------

        public Node WithId(NodeId value)
        {
            var c = this.Clone();
            c.Id = value;
            return c;
        }

        // -----------------------
        // Component
        // -----------------------

        public Node WithComponent(ImmComponent value)
        {
            var c = this.Clone();
            c.Component = value;
            return c;
        }

    }
}
