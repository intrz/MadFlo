using MadFlo;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MadFlo
{
    public sealed class Graph
    {
        public GraphId Id { get;  private set; }
        public GraphName Name { get;  private set; }
        //public ImmutableList<Node> Nodes { get;  private set; }
        public ImmutableDictionary<NodeId, Node> Nodes { get; private set; }
        public ImmutableList<Socket> Edges { get;  private set; }
        public ImmutableList<Initial> Initials { get;  private set; }

        public Graph()
        {
            Id = GraphId.Empty;
            Name = GraphName.Empty;
            Nodes = ImmutableDictionary.Create<NodeId,Node>();
            Edges = ImmutableList.Create<Socket>();
            Initials = ImmutableList.Create<Initial>();
        }

        private readonly static Graph _empty = new Graph();
        public static Graph Empty { get { return _empty; }   }

        public bool IsEmpty()
        {
            return this == Empty;
        }


        public Graph GetEmpty()
        {
            return Empty;
        }


        private Graph Clone()
        {
            var c = new Graph();
            c.Id = this.Id;
            c.Name = this.Name;
            c.Nodes = this.Nodes;
            c.Edges = this.Edges;
            c.Initials = this.Initials;
            return c;
        }

        public void Send(object input, NodeId fromNode, OutPortName outPortName)
        {
            Socket mySocket = this.Edges.FirstOrDefault(socket => socket.FromNodeId.Value.Equals(fromNode.Value) && socket.FromPortName.Value.Equals(outPortName.Value));
            var toNodeId = mySocket.ToNodeId;
            var toPortName = mySocket.ToPortName;
            var toNode = this.Nodes[toNodeId];
            var toPort = toNode.Component.InPorts[toPortName];
            toPort.Process.DynamicInvoke(input, this, toNodeId);
        }

        public Graph WithNodes(ImmutableDictionary<NodeId, Node> values)
        {
            var c = this.Clone();
            c.Nodes = values;
            return c;
        }

        public Graph AddNode(NodeId key, Node value)
        {
            return this.WithNodes(this.Nodes.Add(key, value));
        }
        // -----------------------
        // Id
        // -----------------------

        public Graph WithId(GraphId value)
        {
            var c = this.Clone();
            c.Id = value;
            return c;
        }

        // -----------------------
        // Name
        // -----------------------

        public Graph WithName(GraphName value)
        {
            var c = this.Clone();
            c.Name = value;
            return c;
        }

        // -----------------------
        // Nodes
        // -----------------------

        /*public Graph WithNodes(IEnumerable<Node> values)
        {
            var c = this.Clone();
            c.Nodes = values.ToImmutableList();
            return c;
        }

        public Graph AddNodes(IEnumerable<Node> values)
        {
            return this.WithNodes(this.Nodes.AddRange(values));
        }

        public Graph AddNode(Node value)
        {
            return this.WithNodes(this.Nodes.Add(value));
        }


        public Graph InsertNodes(int index, IEnumerable<Node> values)
        {
            return this.WithNodes(this.Nodes.InsertRange(index, values));
        }


        public Graph InsertNode(int index, Node value)
        {
            return this.WithNodes(this.Nodes.Insert(index, value));
        }


        public Graph ReplaceNode(Node oldValue, Node newValue)
        {
            return this.WithNodes(this.Nodes.Replace(oldValue, newValue));
        }


        public Graph RemoveNode(Node value)
        {
            return this.WithNodes(this.Nodes.Remove(value));
        }
        */
        // -----------------------
        // Edges
        // -----------------------

        public Graph WithEdges(IEnumerable<Socket> values)
        {
            var c = this.Clone();
            c.Edges = values.ToImmutableList();
            return c;
        }

        public Graph AddEdges(IEnumerable<Socket> values)
        {
            return this.WithEdges(this.Edges.AddRange(values));
        }

        public Graph AddEdge(Socket value)
        {
            return this.WithEdges(this.Edges.Add(value));
        }


        public Graph InsertEdges(int index, IEnumerable<Socket> values)
        {
            return this.WithEdges(this.Edges.InsertRange(index, values));
        }


        public Graph InsertEdge(int index, Socket value)
        {
            return this.WithEdges(this.Edges.Insert(index, value));
        }


        public Graph ReplaceEdge(Socket oldValue, Socket newValue)
        {
            return this.WithEdges(this.Edges.Replace(oldValue, newValue));
        }


        public Graph RemoveEdge(Socket value)
        {
            return this.WithEdges(this.Edges.Remove(value));
        }

        // -----------------------
        // Initials
        // -----------------------

        public Graph WithInitials(IEnumerable<Initial> values)
        {
            var c = this.Clone();
            c.Initials = values.ToImmutableList();
            return c;
        }



        public Graph AddInitials(IEnumerable<Initial> values)
        {
            return this.WithInitials(this.Initials.AddRange(values));
        }


        public Graph AddInitial(Initial value)
        {
            return this.WithInitials(this.Initials.Add(value));
        }


        public Graph InsertInitials(int index, IEnumerable<Initial> values)
        {
            return this.WithInitials(this.Initials.InsertRange(index, values));
        }


        public Graph InsertInitial(int index, Initial value)
        {
            return this.WithInitials(this.Initials.Insert(index, value));
        }


        public Graph ReplaceInitial(Initial oldValue, Initial newValue)
        {
            return this.WithInitials(this.Initials.Replace(oldValue, newValue));
        }


        public Graph RemoveInitial(Initial value)
        {
            return this.WithInitials(this.Initials.Remove(value));
        }

    }
}
