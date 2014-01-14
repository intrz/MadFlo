using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadFlo
{
    public class Component : IComponent
    {
        Dictionary<PortName, object> portValues;
        public Network Network { get; private set; }
        Dictionary<PortName, List<IComponent>> receivers;

        public Component()
        {
            portValues = new Dictionary<PortName, object>();
            receivers = new Dictionary<PortName, List<IComponent>>();
        }
     /*   public Network Network { get; set; }
//  Component.prototype.description = '';
//    Component.prototype.icon = null;
 //   Component.prototype.isSubgraph
  //  Component.prototype.error
  //  Component.prototype.shutdown
        
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
        */

        public void Receive(PortName name, object value)
        {
            portValues[name] = value;
            foreach (PortName port in portValues.Keys)
            {
                if (portValues[port] != null)
                {
                    Console.Out.Write("Hello world!");
                }
            }
        }

        public void Send(PortName outPortName, object value)
        {
            List<IComponent> receivingComponents = receivers[outPortName];
            foreach (var receiver in receivingComponents)
            {
                receiver.Receive(outPortName, value);
            }
            //Network.Send(outPortName, value);
        }

        public void WithNetwork(Network value)
        {
            Network = value;
        }
    }
}
