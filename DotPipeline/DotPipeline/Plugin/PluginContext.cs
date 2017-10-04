using System;
using System.Collections.Generic;
using System.Reflection;

namespace DotPipeline.Plugin
{
    public class PluginContext
    {
        Dictionary<string, PluginInfo> registeredPlugins;

        internal PluginContext()
        {
            registeredPlugins = new Dictionary<string, PluginInfo>();
        }

        internal void RegisterPlugin(Type type)
        {
            PluginInfo pluginInfo = new PluginInfo(type);
            registeredPlugins.Add(pluginInfo.Name, pluginInfo);
        }

        internal PluginInfo GetPlugin(string name)
        {
            if (!registeredPlugins.ContainsKey(name))
                return null;
            return registeredPlugins[name];
        }

        internal PluginResult Invoke(string name, Settings settings, string command, params object[] args)
        {
            if (!registeredPlugins.ContainsKey(name))
                throw new PluginNotRegisteredException("The plugin is not found in the plugin registry.");

            return registeredPlugins[name].Invoke(settings, command, args);
        }

        private IPlugin InvokeConstructor(IPlugin plugin)
        {
            return (IPlugin)(plugin.GetType().GetConstructor(Type.EmptyTypes).Invoke(new object[] { }));
        }
    }
}
