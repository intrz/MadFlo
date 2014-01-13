using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadFlo
{
    public class Message
    {
        public Component Target { get; set; }
        public Port TargetPort { get; set; }
        public Packet Packet { get; set; }
    }
}
