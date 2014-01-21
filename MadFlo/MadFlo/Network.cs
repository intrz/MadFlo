using MadFlo;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MadFlo
{
    public sealed class Network
    {
        public ImmutableList<ImmComponent> Components { get;  private set; }
        public ImmutableList<Socket> Connections { get;  private set; }
        public ImmutableList<Packet> Initials { get;  private set; }

        public Network()
        {
            Components = ImmutableList.Create<ImmComponent>();
            Connections = ImmutableList.Create<Socket>();
            Initials = ImmutableList.Create<Packet>();
        }

        private readonly static Network _empty = new Network();
        public static Network Empty { get { return _empty; }   }


        public void Send(NodeId nodeId, PortName outPortName, object value) 
        {

        }

        public bool IsEmpty()
        {
            return this == Empty;
        }


        public Network GetEmpty()
        {
            return Empty;
        }


        private Network Clone()
        {
            var c = new Network();
            c.Components = this.Components;
            c.Connections = this.Connections;
            c.Initials = this.Initials;
            return c;
        }

        // -----------------------
        // ImmComponents
        // -----------------------

        public Network WithImmComponents(IEnumerable<ImmComponent> values)
        {
            var c = this.Clone();
            c.Components = values.ToImmutableList();
            return c;
        }


        public Network AddImmComponentsIf(bool condition, IEnumerable<ImmComponent> values)
        {
            return condition ? this.AddImmComponents(values) : this;
        }


        public Network AddImmComponents(IEnumerable<ImmComponent> values)
        {
            return this.WithImmComponents(this.Components.AddRange(values));
        }


        public Network AddImmComponentIf(bool condition, ImmComponent value)
        {
            return condition ? this.AddImmComponent(value) : this;
        }


        public Network AddImmComponent(ImmComponent value)
        {
            return this.WithImmComponents(this.Components.Add(value));
        }


        public Network InsertImmComponents(int index, IEnumerable<ImmComponent> values)
        {
            return this.WithImmComponents(this.Components.InsertRange(index, values));
        }


        public Network InsertImmComponent(int index, ImmComponent value)
        {
            return this.WithImmComponents(this.Components.Insert(index, value));
        }


        public Network ReplaceImmComponent(ImmComponent oldValue, ImmComponent newValue)
        {
            return this.WithImmComponents(this.Components.Replace(oldValue, newValue));
        }


        public Network RemoveImmComponent(ImmComponent value)
        {
            return this.WithImmComponents(this.Components.Remove(value));
        }

        // -----------------------
        // Connections
        // -----------------------

        public Network WithConnections(IEnumerable<Socket> values)
        {
            var c = this.Clone();
            c.Connections = values.ToImmutableList();
            return c;
        }


        public Network AddConnectionsIf(bool condition, IEnumerable<Socket> values)
        {
            return condition ? this.AddConnections(values) : this;
        }


        public Network AddConnections(IEnumerable<Socket> values)
        {
            return this.WithConnections(this.Connections.AddRange(values));
        }


        public Network AddConnectionIf(bool condition, Socket value)
        {
            return condition ? this.AddConnection(value) : this;
        }


        public Network AddConnection(Socket value)
        {
            return this.WithConnections(this.Connections.Add(value));
        }


        public Network InsertConnections(int index, IEnumerable<Socket> values)
        {
            return this.WithConnections(this.Connections.InsertRange(index, values));
        }


        public Network InsertConnection(int index, Socket value)
        {
            return this.WithConnections(this.Connections.Insert(index, value));
        }


        public Network ReplaceConnection(Socket oldValue, Socket newValue)
        {
            return this.WithConnections(this.Connections.Replace(oldValue, newValue));
        }


        public Network RemoveConnection(Socket value)
        {
            return this.WithConnections(this.Connections.Remove(value));
        }

        // -----------------------
        // Initials
        // -----------------------

        public Network WithInitials(IEnumerable<Packet> values)
        {
            var c = this.Clone();
            c.Initials = values.ToImmutableList();
            return c;
        }


        public Network AddInitialsIf(bool condition, IEnumerable<Packet> values)
        {
            return condition ? this.AddInitials(values) : this;
        }


        public Network AddInitials(IEnumerable<Packet> values)
        {
            return this.WithInitials(this.Initials.AddRange(values));
        }


        public Network AddInitialIf(bool condition, Packet value)
        {
            return condition ? this.AddInitial(value) : this;
        }


        public Network AddInitial(Packet value)
        {
            return this.WithInitials(this.Initials.Add(value));
        }


        public Network InsertInitials(int index, IEnumerable<Packet> values)
        {
            return this.WithInitials(this.Initials.InsertRange(index, values));
        }


        public Network InsertInitial(int index, Packet value)
        {
            return this.WithInitials(this.Initials.Insert(index, value));
        }


        public Network ReplaceInitial(Packet oldValue, Packet newValue)
        {
            return this.WithInitials(this.Initials.Replace(oldValue, newValue));
        }


        public Network RemoveInitial(Packet value)
        {
            return this.WithInitials(this.Initials.Remove(value));
        }

        // -----------------------
        // With
        // -----------------------

        public Network WithIf(bool condition, Func<Network, Network> arg)
        {
            return condition ? With(arg) : this;
        }


        public Network With(Func<Network, Network> arg)
        {
            return arg.Invoke(this);
        }

    }
}
