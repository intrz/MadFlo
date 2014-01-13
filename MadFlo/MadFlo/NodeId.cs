using Mad.Serdo;
using MadFlo;
using System;
using System.Linq;

namespace MadFlo
{
    public sealed class NodeId : IEmpty<NodeId>
    {
        public string Value { get;  private set; }

        public NodeId()
        {
            Value = string.Empty;
        }

        private readonly static NodeId _empty = new NodeId();
        public static NodeId Empty { get { return _empty; }   }

        public bool IsEmpty()
        {
            return this == Empty;
        }


        public NodeId GetEmpty()
        {
            return Empty;
        }


        private NodeId Clone()
        {
            var c = new NodeId();
            c.Value = this.Value;
            return c;
        }

        // -----------------------
        // Value
        // -----------------------

        public NodeId WithValue(string value)
        {
            var c = this.Clone();
            c.Value = value;
            return c;
        }

        // -----------------------
        // With
        // -----------------------

        public NodeId WithIf(bool condition, Func<NodeId, NodeId> arg)
        {
            return condition ? With(arg) : this;
        }


        public NodeId With(Func<NodeId, NodeId> arg)
        {
            return arg.Invoke(this);
        }

    }
}
