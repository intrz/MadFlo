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
        public InPort TargetPort { get; set; }
        public Initial Packet { get; set; }
    }
}
