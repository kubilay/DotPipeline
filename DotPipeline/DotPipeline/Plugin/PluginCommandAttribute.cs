using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotPipeline.Plugin
{
    [System.AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class PluginCommandAttribute : Attribute
    {
        readonly string name;

        public PluginCommandAttribute(string name)
        {
            this.name = name;
        }

        public string Name { get => name; }
    }
}
