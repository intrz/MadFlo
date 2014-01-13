using MadFlo;
using System;
using System.Linq;

namespace MadFlo
{
    public sealed class Socket
    {
        public NodeId NodeId { get;  private set; }
        public PortName PortName { get; private set; }

        public Socket()
        {
            NodeId = NodeId.Empty;
            PortName = PortName.Empty;
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
            c.NodeId = this.NodeId;
            c.PortName = this.PortName;
            return c;
        }

        public Socket WithNodeId(NodeId value)
        {
            var c = this.Clone();
            c.NodeId = value;
            return c;
        }

        public Socket WithPortName(PortName value)
        {
            var c = this.Clone();
            c.PortName = value;
            return c;
        }

    }
}
