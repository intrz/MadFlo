using MadFlo;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MadFlo
{
    public sealed class Network
    {
        public ImmutableList<Component> Components { get;  private set; }
        public ImmutableList<Socket> Connections { get;  private set; }
        public ImmutableList<Packet> Initials { get;  private set; }

        public Network()
        {
            Components = ImmutableList.Create<Component>();
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
        // Components
        // -----------------------

        public Network WithComponents(IEnumerable<Component> values)
        {
            var c = this.Clone();
            c.Components = values.ToImmutableList();
            return c;
        }


        public Network AddComponentsIf(bool condition, IEnumerable<Component> values)
        {
            return condition ? this.AddComponents(values) : this;
        }


        public Network AddComponents(IEnumerable<Component> values)
        {
            return this.WithComponents(this.Components.AddRange(values));
        }


        public Network AddComponentIf(bool condition, Component value)
        {
            return condition ? this.AddComponent(value) : this;
        }


        public Network AddComponent(Component value)
        {
            return this.WithComponents(this.Components.Add(value));
        }


        public Network InsertComponents(int index, IEnumerable<Component> values)
        {
            return this.WithComponents(this.Components.InsertRange(index, values));
        }


        public Network InsertComponent(int index, Component value)
        {
            return this.WithComponents(this.Components.Insert(index, value));
        }


        public Network ReplaceComponent(Component oldValue, Component newValue)
        {
            return this.WithComponents(this.Components.Replace(oldValue, newValue));
        }


        public Network RemoveComponent(Component value)
        {
            return this.WithComponents(this.Components.Remove(value));
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
