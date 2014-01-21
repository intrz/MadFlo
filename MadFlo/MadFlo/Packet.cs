using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadFlo
{
    public sealed class Packet
    {
        public object Value { get;  private set; }
        public NodeId ToNodeId { get; private set; }
        public PortName ToPortName { get; private set; }

        public Packet()
        {
            Value = string.Empty;
            ToNodeId = NodeId.Empty;
            ToPortName = PortName.Empty;
        }

        private readonly static Packet _empty = new Packet();
        public static Packet Empty { get { return _empty; } }

        public bool IsEmpty()
        {
            return this == Empty;
        }


        public Packet GetEmpty()
        {
            return Empty;
        }


        private Packet Clone()
        {
            var c = new Packet();
            c.Value = this.Value;
            c.ToNodeId = this.ToNodeId;
            c.ToPortName = this.ToPortName;
            return c;
        }

        public Packet WithValue(object value)
        {
            var c = this.Clone();
            c.Value = value;
            return c;
        }

        public Packet WithToNodeId(NodeId value)
        {
            var c = this.Clone();
            c.ToNodeId = value;
            return c;
        }

        public Packet WithToPortName(PortName value)
        {
            var c = this.Clone();
            c.ToPortName = value;
            return c;
        }
    }
}
