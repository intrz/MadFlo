using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadFlo
{
    public sealed class Initial
    {
        public object Value { get;  private set; }
        public NodeId ToNodeId { get; private set; }
        public InPortName ToPortName { get; private set; }
        public GraphId GraphId { get; private set; }

        public Initial()
        {
            Value = string.Empty;
            ToNodeId = NodeId.Empty;
            ToPortName = InPortName.Empty;
            GraphId = GraphId.Empty;
        }

        private readonly static Initial _empty = new Initial();
        public static Initial Empty { get { return _empty; } }

        public bool IsEmpty()
        {
            return this == Empty;
        }


        public Initial GetEmpty()
        {
            return Empty;
        }


        private Initial Clone()
        {
            var c = new Initial();
            c.Value = this.Value;
            c.ToNodeId = this.ToNodeId;
            c.ToPortName = this.ToPortName;
            return c;
        }

        public Initial WithValue(object value)
        {
            var c = this.Clone();
            c.Value = value;
            return c;
        }

        public Initial WithToNodeId(NodeId value)
        {
            var c = this.Clone();
            c.ToNodeId = value;
            return c;
        }

        public Initial WithToPortName(InPortName value)
        {
            var c = this.Clone();
            c.ToPortName = value;
            return c;
        }
    }
}
