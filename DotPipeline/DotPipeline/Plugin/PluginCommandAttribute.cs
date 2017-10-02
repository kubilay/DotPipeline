using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotPipeline.Plugin
{
    public class PluginCommandAttribute : Attribute
    {
        public string Name { get; set; }
        public  PluginCommandAttribute()
        {
        }
    }
}
