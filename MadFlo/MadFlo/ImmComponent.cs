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
        public int MajorVersion { get; private set; }
        public int MinorVersion { get; private set; }
        public string Name { get; private set; }
        public ImmutableDictionary<InPortName, InPort> InPorts { get; private set; }
        public ImmutableDictionary<OutPortName, OutPort> OutPorts { get; private set; }

        public ImmComponent()
        {
            Properties = ImmutableDictionary.Create<string, object>();
            Functions = ImmutableList.Create<Delegate>();
            InPorts = ImmutableDictionary.Create<InPortName, InPort>();
            OutPorts = ImmutableDictionary.Create<OutPortName, OutPort>();
            MinorVersion = 0;
            MajorVersion = 0;
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
            c.InPorts = this.InPorts;
            c.OutPorts = this.OutPorts;
            c.MinorVersion = this.MinorVersion;
            c.MajorVersion = this.MajorVersion;
            return c;
        }

        public ImmComponent WithName(string value)
        {
            var c = this.Clone();
            c.Name = value;
            return c;
        }

        public ImmComponent WithOutPorts(ImmutableDictionary<OutPortName, OutPort> values)
        {
            var c = this.Clone();
            c.OutPorts = values;
            c.MajorVersion += 1;
            return c;
        }

        public ImmComponent AddOutPort(OutPortName key, OutPort value)
        {
            return this.WithOutPorts(this.OutPorts.Add(key, value));
        }

        public ImmComponent WithInPorts(ImmutableDictionary<InPortName, InPort> values)
        {
            var c = this.Clone();
            c.InPorts = values;
            c.MajorVersion += 1;
            return c;
        }

        public ImmComponent AddInPort(InPortName key, InPort value)
        {
            return this.WithInPorts(this.InPorts.Add(key, value));
        }

        public ImmComponent WithProperties(ImmutableDictionary<string, object> values)
        {
            var c = this.Clone();
            c.Properties = values;
            c.MinorVersion += 1;
            return c;
        }

        public ImmComponent AddProperty(string key, object value)
        {
            return this.WithProperties(this.Properties.Add(key, value));
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
            c.MinorVersion += 1;
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
