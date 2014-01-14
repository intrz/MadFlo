using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadFlo
{
    public sealed class Comp
    {
        public ImmutableDictionary<string, object> Properties { get; private set; }
        public ImmutableList<Delegate> Functions { get; private set; }        

        public Comp()
        {
            Func<int, String, String> myFunc = new Func<int, string, string>((i, s) => "ID: " + i + " Name: " + s);
            Action<String, String> myaction = new Action<string, string>((x,y) => x=y);
            myaction("", "");
            myFunc(1, "");
            Functions.Add(myFunc);
            Functions.Add(myaction);
        }
    }
}
