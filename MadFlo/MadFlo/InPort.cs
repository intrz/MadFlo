using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadFlo
{
    public sealed class InPort
    {
        //public NodeId FromNodeId { get;  private set; }
        public InPortName Name { get; private set; }
        //public NodeId ToNodeId { get; private set; }
        public PortType PortType { get; private set; }
        public Delegate Process { get; private set; }

        public InPort()
        {
            //FromNodeId = NodeId.Empty;
            Name = InPortName.Empty;
            //ToNodeId = NodeId.Empty;
            PortType = PortType.Empty;
            Process = new Action(() => { });
        }

        private readonly static InPort _empty = new InPort();
        public static InPort Empty { get { return _empty; } }

        public bool IsEmpty()
        {
            return this == Empty;
        }


        public InPort GetEmpty()
        {
            return Empty;
        }


        private InPort Clone()
        {
            var c = new InPort();
            //c.FromNodeId = this.FromNodeId;
            c.Name = this.Name;
            c.PortType = this.PortType;
            c.Process = this.Process;
            //c.ToNodeId = this.ToNodeId;
            return c;
        }

        public InPort WithName(InPortName value)
        {
            var c = this.Clone();
            c.Name = value;
            return c;
        }

        public InPort WithPortType(PortType value)
        {
            var c = this.Clone();
            c.PortType = value;
            return c;
        }

        public InPort WithProcess(Delegate value)
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
