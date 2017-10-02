using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DotPipeline.Plugin
{
    public class PluginContext
    {
        Dictionary<string, IPlugin> registeredPlugins;
        Dictionary<string, Dictionary<string, MethodInfo>> registeredCommands;

        PluginContext()
        {
            registeredPlugins = new Dictionary<string, IPlugin>();
            registeredCommands = new Dictionary<string, Dictionary<string, MethodInfo>>();
        }

        public void RegisterPlugin(IPlugin plugin)
        {
            registeredPlugins.Add(plugin.Name, plugin);
            Type pluginType = plugin.GetType();
            registeredCommands.Add(plugin.Name, new Dictionary<string, MethodInfo>());

            MethodInfo[] methodInfos = pluginType.GetMethods();
            foreach (MethodInfo methodInfo in methodInfos)
            {
                if (methodInfo.ReturnType == typeof(bool))
                {
                    PluginCommandAttribute pluginCommandAttribute = methodInfo.GetCustomAttribute<PluginCommandAttribute>();
                    if (pluginCommandAttribute != null)
                        registeredCommands[plugin.Name].Add(pluginCommandAttribute.Name, methodInfo);
                }
            }
        }

        public IPlugin GetPlugin(string name)
        {
            if (!registeredPlugins.ContainsKey(name))
                return null;
            return registeredPlugins[name];
        }

        public bool Invoke(string name, Settings settings, string command, params object[] args)
        {
            if (!registeredPlugins.ContainsKey(name))
                throw new PluginNotRegisteredException("The plugin is not found in the plugin registry.");
            if (!registeredCommands[name].ContainsKey(command))
                throw new PluginCommandNotAvailableException("The plugin does not expose any method as expected for the given name.");

            if (CheckMethodParameterTypes(registeredCommands[name][command], args))
                throw new PluginCommandArgumentException("The plugin does not contain any exposed commands for the given signature.");

            IPlugin plugin = InvokeConstructor(registeredPlugins[name]);
            plugin.Initialize(settings);

            return (bool)(registeredCommands[name][command].Invoke(plugin, args));
        }

        private IPlugin InvokeConstructor(IPlugin plugin)
        {
            return (IPlugin)(plugin.GetType().GetConstructor(Type.EmptyTypes).Invoke(new object[] { }));
        }

        private bool CheckMethodParameterTypes(MethodInfo methodInfo, object[] args)
        {
            int i = 0;
            ParameterInfo[] parameterInfos = methodInfo.GetParameters();

            if (parameterInfos.Length != args.Length)
                return false;

            foreach (ParameterInfo parameterInfo in parameterInfos)
            {
                if (parameterInfo.ParameterType != args[i].GetType())
                    return false;
            }
            return true;
        }
    }
}
