using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadFlo
{
    public sealed class Port
    {
        //public NodeId FromNodeId { get;  private set; }
        public PortName Name { get; private set; }
        //public NodeId ToNodeId { get; private set; }
        public PortType PortType { get; private set; }
        public Delegate Process { get; private set; }

        public Port()
        {
            //FromNodeId = NodeId.Empty;
            Name = PortName.Empty;
            //ToNodeId = NodeId.Empty;
            PortType = PortType.Empty;
            Process = new Action(() => { });
        }

        private readonly static Port _empty = new Port();
        public static Port Empty { get { return _empty; } }

        public bool IsEmpty()
        {
            return this == Empty;
        }


        public Port GetEmpty()
        {
            return Empty;
        }


        private Port Clone()
        {
            var c = new Port();
            //c.FromNodeId = this.FromNodeId;
            c.Name = this.Name;
            c.PortType = this.PortType;
            c.Process = this.Process;
            //c.ToNodeId = this.ToNodeId;
            return c;
        }

        public Port WithName(PortName value)
        {
            var c = this.Clone();
            c.Name = value;
            return c;
        }

        public Port WithPortType(PortType value)
        {
            var c = this.Clone();
            c.PortType = value;
            return c;
        }

        public Port WithProcess(Delegate value)
        {
            var c = this.Clone();
            c.Process = value;
            return c;
        }

        /*public Port WithFromNodeId(NodeId value)
        {
            var c = this.Clone();
            c.FromNodeId = value;
            return c;
        }*/

      //type
      //socket
      //from
      //node
      //name
    }
}
