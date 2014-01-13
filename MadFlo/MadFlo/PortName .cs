using MadFlo;
using System;
using System.Linq;

namespace MadFlo
{
    public sealed class PortName
    {
        public string Value { get;  private set; }

        public PortName()
        {
            Value = string.Empty;
        }

        private readonly static PortName _empty = new PortName();
        public static PortName Empty { get { return _empty; }   }

        public bool IsEmpty()
        {
            return this == Empty;
        }


        public PortName GetEmpty()
        {
            return Empty;
        }


        private PortName Clone()
        {
            var c = new PortName();
            c.Value = this.Value;
            return c;
        }

        // -----------------------
        // Value
        // -----------------------

        public PortName WithValue(string value)
        {
            var c = this.Clone();
            c.Value = value;
            return c;
        }

        // -----------------------
        // With
        // -----------------------

        public PortName WithIf(bool condition, Func<PortName, PortName> arg)
        {
            return condition ? With(arg) : this;
        }


        public PortName With(Func<PortName, PortName> arg)
        {
            return arg.Invoke(this);
        }

    }
}
