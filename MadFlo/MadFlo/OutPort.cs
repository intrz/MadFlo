using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadFlo
{
    public sealed class OutPort
    {
        public OutPortName Name { get; private set; }
        public PortType PortType { get; private set; }

        public OutPort()
        {
            Name = OutPortName.Empty;
            PortType = PortType.Empty;
        }

        private readonly static OutPort _empty = new OutPort();
        public static OutPort Empty { get { return _empty; } }

        public bool IsEmpty()
        {
            return this == Empty;
        }


        public OutPort GetEmpty()
        {
            return Empty;
        }


        private OutPort Clone()
        {
            var c = new OutPort();
            c.Name = this.Name;
            c.PortType = this.PortType;
            return c;
        }

        public OutPort WithName(OutPortName value)
        {
            var c = this.Clone();
            c.Name = value;
            return c;
        }

        public OutPort WithPortType(PortType value)
        {
            var c = this.Clone();
            c.PortType = value;
            return c;
        }
    }
}
