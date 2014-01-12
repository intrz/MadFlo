using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadFlo
{
    public sealed class GraphProperty
    {
        public string Key { get; private set; }
        public string Value { get; private set; }

        public GraphProperty()
        {
            Value = string.Empty;
            Key = string.Empty;
        }

        private readonly static GraphProperty _empty = new GraphProperty();
        public static GraphProperty Empty { get { return _empty; } }

        public bool IsEmpty()
        {
            return this == Empty;
        }


        public GraphProperty GetEmpty()
        {
            return Empty;
        }


        private GraphProperty Clone()
        {
            var c = new GraphProperty();
            c.Value = this.Value;
            c.Key = this.Key;
            return c;
        }

        // -----------------------
        // Value
        // -----------------------

        public GraphProperty WithValue(string value)
        {
            var c = this.Clone();
            c.Value = value;
            return c;
        }

        public GraphProperty WithKey(string value)
        {
            var c = this.Clone();
            c.Key = value;
            return c;
        }

    }
}
