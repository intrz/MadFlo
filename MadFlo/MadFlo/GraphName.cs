using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadFlo
{
    public sealed class GraphName
    {
        public string Value { get; private set; }

        public GraphName()
        {
            Value = string.Empty;
        }

        private readonly static GraphName _empty = new GraphName();
        public static GraphName Empty { get { return _empty; } }

        public bool IsEmpty()
        {
            return this == Empty;
        }


        public GraphName GetEmpty()
        {
            return Empty;
        }


        private GraphName Clone()
        {
            var c = new GraphName();
            c.Value = this.Value;
            return c;
        }

        // -----------------------
        // Value
        // -----------------------

        public GraphName WithValue(string value)
        {
            var c = this.Clone();
            c.Value = value;
            return c;
        }

    }
}
