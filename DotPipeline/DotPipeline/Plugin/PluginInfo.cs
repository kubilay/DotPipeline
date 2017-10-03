using System;
using System.Collections.Generic;
using System.Reflection;

namespace DotPipeline.Plugin
{
    internal class PluginInfo
    {
        private Type type;
        private Dictionary<string, PluginMethodInfo> commands;

        public readonly string Name;

        public PluginInfo(Type type)
        {
            this.type = type;
            string name = type.GetCustomAttribute<PluginAttribute>().Name;
            if (name == null)
                throw new PluginNameNotDefinedException("");
            Name = name;
            this.commands = new Dictionary<string, PluginMethodInfo>();
            GetCommands();
        }

        private void GetCommands()
        {
            MethodInfo[] methodInfos = type.GetMethods();

            foreach (MethodInfo methodInfo in methodInfos)
            {
                if (methodInfo.ReturnType == typeof(PluginResult))
                {
                    PluginCommandAttribute pluginCommand = methodInfo.GetCustomAttribute<PluginCommandAttribute>();
                    if (pluginCommand != null)
                        commands.Add(pluginCommand.Name, new PluginMethodInfo(methodInfo));
                }
            }
        }

        internal IPlugin InvokeConstructor()
        {
            return (IPlugin)(type.GetConstructor(Type.EmptyTypes).Invoke(new object[] { }));
        }

        private bool HasCommand(string command)
        {
            return commands.ContainsKey(command);
        }

        internal PluginResult Invoke(Settings settings, string name, params object[] args)
        {
            if (!HasCommand(name))
                throw new PluginCommandNotAvailableException("The plugin does not expose any method as expected for the given name.");

            if (!commands[name].CheckMethodParameterTypes(args))
                throw new PluginCommandArgumentException("The plugin does not contain any exposed commands with the given signature.");

            IPlugin plugin = InvokeConstructor();
            plugin.Initialize(settings);

            return (PluginResult)(commands[name].Invoke(plugin, args));
        }
    }
}