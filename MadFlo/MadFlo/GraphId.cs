using Mad.Serdo;
using MadFlo;
using System;
using System.Linq;

namespace MadFlo
{
    public sealed class GraphId : IEmpty<GraphId>
    {
        public string Value { get;  private set; }

        public GraphId()
        {
            Value = string.Empty;
        }

        private readonly static GraphId _empty = new GraphId();
        public static GraphId Empty { get { return _empty; }   }

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

        // -----------------------
        // With
        // -----------------------

        public GraphId WithIf(bool condition, Func<GraphId, GraphId> arg)
        {
            return condition ? With(arg) : this;
        }


        public GraphId With(Func<GraphId, GraphId> arg)
        {
            return arg.Invoke(this);
        }

    }
}
