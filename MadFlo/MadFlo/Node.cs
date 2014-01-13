using MadFlo;
using System;
using System.Linq;

namespace MadFlo
{
    public sealed class Node
    {
        public NodeId Id { get;  private set; }
        public IComponent Component { get;  private set; }

        public Node()
        {
            Id = NodeId.Empty;
            Component = new Component();
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

        public Node WithComponent(IComponent value)
        {
            var c = this.Clone();
            c.Component = value;
            return c;
        }

        // -----------------------
        // With
        // -----------------------

        public Node WithIf(bool condition, Func<Node, Node> arg)
        {
            return condition ? With(arg) : this;
        }


        public Node With(Func<Node, Node> arg)
        {
            return arg.Invoke(this);
        }

    }
}
