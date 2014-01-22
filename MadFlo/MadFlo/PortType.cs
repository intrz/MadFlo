using MadFlo;
using System;
using System.Linq;

namespace MadFlo
{
    public sealed class PortType
    {
        public string Value { get;  private set; }

        public PortType()
        {
            Value = string.Empty;
        }

        private readonly static PortType _empty = new PortType();
        public static PortType Empty { get { return _empty; } }

        public bool IsEmpty()
        {
            return this == Empty;
        }


        public PortType GetEmpty()
        {
            return Empty;
        }


        private PortType Clone()
        {
            var c = new PortType();
            c.Value = this.Value;
            return c;
        }

        // -----------------------
        // Value
        // -----------------------

        public PortType WithValue(string value)
        {
            var c = this.Clone();
            c.Value = value;
            return c;
        }


    }
}
