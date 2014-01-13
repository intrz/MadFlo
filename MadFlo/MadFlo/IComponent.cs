using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadFlo
{
    public interface IComponent
    {
        void Send(PortName outPort, object value);
        void Receive(PortName portName, object value);
        void WithNetwork(Network network);
    }
}
