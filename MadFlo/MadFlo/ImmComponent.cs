using MadFlo;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MadFlo
{
    public sealed class ImmComponent
    {
        public ImmutableDictionary<string, object> Properties { get;  private set; }
        public ImmutableList<Delegate> Functions { get;  private set; }
        public ImmutableDictionary<PortName, Delegate> Ports { get; private set; }
        public int Version { get; private set; }

        public ImmComponent()
        {
            Properties = ImmutableDictionary.Create<string, object>();
            Functions = ImmutableList.Create<Delegate>();
            Ports = ImmutableDictionary.Create<PortName, Delegate>();
            Version = 0;
        }

        private readonly static ImmComponent _empty = new ImmComponent();
        public static ImmComponent Empty { get { return _empty; }   }

        public bool IsEmpty()
        {
            return this == Empty;
        }


        public ImmComponent GetEmpty()
        {
            return Empty;
        }


        private ImmComponent Clone()
        {
            var c = new ImmComponent();
            c.Properties = this.Properties;
            c.Functions = this.Functions;
            c.Ports = this.Ports;
            c.Version = this.Version;
            return c;
        }

        // -----------------------
        // Properties
        // -----------------------

        public ImmComponent WithPorts(ImmutableDictionary<PortName, Delegate> values)
        {
            var c = this.Clone();
            c.Ports = values;
            c.Version += 1;
            return c;
        }

        public ImmComponent WithProperties(ImmutableDictionary<string, object> values)
        {
            var c = this.Clone();
            c.Properties = values;
            c.Version += 1;
            return c;
        }

        public ImmComponent AddProperty(string key, object value)
        {
            return this.WithProperties(this.Properties.Add(key, value));
        }

        public ImmComponent AddPort(PortName key, Delegate value)
        {
            return this.WithPorts(this.Ports.Add(key, value));
        }


        /*public ImmComponent InsertProperties(int index, IEnumerable<string> values)
        {
            return this.WithProperties(this.Properties.InsertRange(index, values));
        }


        public ImmComponent InsertProperty(int index, string value)
        {
            return this.WithProperties(this.Properties.Insert(index, value));
        }


        public ImmComponent ReplaceProperty(string oldValue, string newValue)
        {
            return this.WithProperties(this.Properties.Replace(oldValue, newValue));
        }*/


        public ImmComponent RemoveProperty(string value)
        {
            return this.WithProperties(this.Properties.Remove(value));
        }

        // -----------------------
        // Functions
        // -----------------------

        public ImmComponent WithFunctions(IEnumerable<Delegate> values)
        {
            var c = this.Clone();
            c.Functions = values.ToImmutableList();
            c.Version += 1;
            return c;
        }

        public ImmComponent AddFunctions(IEnumerable<Delegate> values)
        {
            return this.WithFunctions(this.Functions.AddRange(values));
        }

        public ImmComponent AddFunction(Delegate value)
        {
            return this.WithFunctions(this.Functions.Add(value));
        }


        public ImmComponent InsertFunctions(int index, IEnumerable<Delegate> values)
        {
            return this.WithFunctions(this.Functions.InsertRange(index, values));
        }


        public ImmComponent InsertFunction(int index, Delegate value)
        {
            return this.WithFunctions(this.Functions.Insert(index, value));
        }


        public ImmComponent ReplaceFunction(Delegate oldValue, Delegate newValue)
        {
            return this.WithFunctions(this.Functions.Replace(oldValue, newValue));
        }


        public ImmComponent RemoveFunction(Delegate value)
        {
            return this.WithFunctions(this.Functions.Remove(value));
        }


    }
}
