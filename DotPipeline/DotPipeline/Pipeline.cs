using DotPipeline.Plugin;

namespace DotPipeline
{
    class Pipeline
    {
        PluginContext pluginContext;
        Settings settings;

        public Pipeline()
        {
            pluginContext = new PluginContext();
            settings = new Settings();
        }

        public void Process()
        {

        }
    }
}
