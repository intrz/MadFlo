using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadFlo
{
    public sealed class GraphId
    {
        public string Value { get; private set; }

        public GraphId()
        {
            Value = string.Empty;
        }

        private readonly static GraphId _empty = new GraphId();
        public static GraphId Empty { get { return _empty; } }

        public bool IsEmpty()
        {
            return this == Empty;
        }


        public GraphId GetEmpty()
        {
            return Empty;
        }


        private GraphId Clone()
        {
            var c = new GraphId();
            c.Value = this.Value;
            return c;
        }

        // -----------------------
        // Value
        // -----------------------

        public GraphId WithValue(string value)
        {
            var c = this.Clone();
            c.Value = value;
            return c;
        }

    }
}
