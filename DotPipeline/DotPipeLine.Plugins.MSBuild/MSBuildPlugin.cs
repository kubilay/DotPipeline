using DotPipeline.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotPipeline;

namespace DotPipeLine.Plugins.MSBuild
{
    public class MSBuildPlugin : IPlugin
    {
        public string Name { get => "DotPipeline.MSBuildPlugin"; }
        string MSBuildPath;

        public void Initialize(Settings settings)
        {
            MSBuildPath = settings.GetString("MSBuildPath");
            
        }

        [PluginCommand(Name = "Build")]
        public bool Build()
        {
            return true;
        }
    }
}
