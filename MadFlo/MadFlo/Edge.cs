using MadFlo;
using System;
using System.Linq;

namespace MadFlo
{
    public sealed class Edge
    {
        public string Value { get;  private set; }

        public Edge()
        {
            Value = string.Empty;
        }

        private readonly static Edge _empty = new Edge();
        public static Edge Empty { get { return _empty; }   }

        public bool IsEmpty()
        {
            return this == Empty;
        }


        public Edge GetEmpty()
        {
            return Empty;
        }


        private Edge Clone()
        {
            var c = new Edge();
            c.Value = this.Value;
            return c;
        }

        public Edge WithValue(string value)
        {
            var c = this.Clone();
            c.Value = value;
            return c;
        }

    }
}
