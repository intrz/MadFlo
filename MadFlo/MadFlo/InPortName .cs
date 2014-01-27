using MadFlo;
using System;
using System.Linq;

namespace MadFlo
{
    public sealed class InPortName
    {
        public string Value { get;  private set; }

        public InPortName()
        {
            Value = string.Empty;
        }

        private readonly static InPortName _empty = new InPortName();
        public static InPortName Empty { get { return _empty; }   }

        public bool IsEmpty()
        {
            return this == Empty;
        }


        public InPortName GetEmpty()
        {
            return Empty;
        }


        private InPortName Clone()
        {
            var c = new InPortName();
            c.Value = this.Value;
            return c;
        }

        // -----------------------
        // Value
        // -----------------------

        public InPortName WithValue(string value)
        {
            var c = this.Clone();
            c.Value = value;
            return c;
        }

        // -----------------------
        // With
        // -----------------------

        public InPortName WithIf(bool condition, Func<InPortName, InPortName> arg)
        {
            return condition ? With(arg) : this;
        }


        public InPortName With(Func<InPortName, InPortName> arg)
        {
            return arg.Invoke(this);
        }

    }
}
