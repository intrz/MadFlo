﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadFlo
{
    public static class NetworkProtocol
    {
        public static Func<Graph, Network> Start = (graph) =>
        {
            //Runtime.Run(network)
            return null;
        };

        public static Func<Graph, Network> Stop = (graph) =>
        {
            //Runtime.Stop(network)
            return null;
        };

        public static Func<Edge, Graph, Graph> Connect = (edge, graph) =>
        {
            return null;
        };

        public static Func<Edge, Initial, Graph, Graph> Data = (edge, packet, graph) =>
        {
            return null;
        };

        public static Network AddNode(Network network, Component process)
        {
            //var retVal =  network.AddProcess(process);

            //send(retVal)
            return null;
        }
    }
}
