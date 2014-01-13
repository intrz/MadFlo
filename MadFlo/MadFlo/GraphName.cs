using Mad.Serdo;
using MadFlo;
using System;
using System.Linq;

namespace MadFlo
{
    public sealed class GraphName : IEmpty<GraphName>
    {
        public string Value { get;  private set; }

        public GraphName()
        {
            Value = string.Empty;
        }

        private readonly static GraphName _empty = new GraphName();
        public static GraphName Empty { get { return _empty; }   }

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

        // -----------------------
        // With
        // -----------------------

        public GraphName WithIf(bool condition, Func<GraphName, GraphName> arg)
        {
            return condition ? With(arg) : this;
        }


        public GraphName With(Func<GraphName, GraphName> arg)
        {
            return arg.Invoke(this);
        }

    }
}
