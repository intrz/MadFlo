using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadFlo
{
    public sealed class NodeId
    {
        public string Value { get; private set; }

        public NodeId()
        {
            Value = string.Empty;
        }

        private readonly static NodeId _empty = new NodeId();
        public static NodeId Empty { get { return _empty; } }

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

    }
}
