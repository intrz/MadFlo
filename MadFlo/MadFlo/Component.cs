using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadFlo
{
    public class Component
    {
        public Network Network { get; set; }
/*  Component.prototype.description = '';
    Component.prototype.icon = null;
    Component.prototype.isSubgraph
    Component.prototype.error
    Component.prototype.shutdown
        */
        public void Send(Message message)
        {
            //network.SendMessage(message)
        }

        public void Connect(Port outPort, Component target, Port targetPort)
        {
            //connections[outPort].target = target;
            //connections[outPort].targetPort = targetPort;
        }

        public void SetNetwork(Network network)
        {

        }
    }
}
