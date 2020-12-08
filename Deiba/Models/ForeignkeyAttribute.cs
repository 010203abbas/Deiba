using System;

namespace Deiba.Models
{
    internal class ForeignkeyAttribute : Attribute
    {
        private string v;

        public ForeignkeyAttribute(string v)
        {
            this.v = v;
        }
    }
}