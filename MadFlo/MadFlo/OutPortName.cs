using MadFlo;
using System;
using System.Linq;

namespace MadFlo
{
    public sealed class OutPortName
    {
        public string Value { get;  private set; }

        public OutPortName()
        {
            Value = string.Empty;
        }

        private readonly static OutPortName _empty = new OutPortName();
        public static OutPortName Empty { get { return _empty; }   }

        public bool IsEmpty()
        {
            return this == Empty;
        }


        public OutPortName GetEmpty()
        {
            return Empty;
        }


        private OutPortName Clone()
        {
            var c = new OutPortName();
            c.Value = this.Value;
            return c;
        }

        // -----------------------
        // Value
        // -----------------------

        public OutPortName WithValue(string value)
        {
            var c = this.Clone();
            c.Value = value;
            return c;
        }

        // -----------------------
        // With
        // -----------------------

        public OutPortName WithIf(bool condition, Func<OutPortName, OutPortName> arg)
        {
            return condition ? With(arg) : this;
        }


        public OutPortName With(Func<OutPortName, OutPortName> arg)
        {
            return arg.Invoke(this);
        }

    }
}
