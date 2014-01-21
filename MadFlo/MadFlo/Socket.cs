using MadFlo;
using System;
using System.Linq;

namespace MadFlo
{
    public sealed class Socket
    {
        public NodeId FromNodeId { get;  private set; }
        public PortName FromPortName { get; private set; }
        public NodeId ToNodeId { get; private set; }
        public PortName ToPortName { get; private set; }

        public Socket()
        {
            FromNodeId = NodeId.Empty;
            FromPortName = PortName.Empty;
            ToNodeId = NodeId.Empty;
            ToPortName = PortName.Empty;
        }

        private readonly static Socket _empty = new Socket();
        public static Socket Empty { get { return _empty; }   }

        public bool IsEmpty()
        {
            return this == Empty;
        }


        public Socket GetEmpty()
        {
            return Empty;
        }


        private Socket Clone()
        {
            var c = new Socket();
            c.FromNodeId = this.FromNodeId;
            c.FromPortName = this.FromPortName;
            c.ToNodeId = this.ToNodeId;
            c.ToPortName = this.ToPortName;
            return c;
        }

        public Socket WithFromNodeId(NodeId value)
        {
            var c = this.Clone();
            c.FromNodeId = value;
            return c;
        }

        public Socket WithFromPortName(PortName value)
        {
            var c = this.Clone();
            c.FromPortName = value;
            return c;
        }


        public Socket WithToNodeId(NodeId value)
        {
            var c = this.Clone();
            c.ToNodeId = value;
            return c;
        }

        public Socket WithToPortName(PortName value)
        {
            var c = this.Clone();
            c.ToPortName = value;
            return c;
        }

    }
}
