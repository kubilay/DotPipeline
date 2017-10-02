using DotPipeline.Plugin;
using System;

namespace DotPipeline
{
    public class PluginAction : IAction
    {
        bool result;
        public bool Result { get => result; private set => result = value; }
        string Name;
        Settings Settings;
        string Command;
        object[] Args;

        public PluginAction(string name, Settings settings, string command, params object[] args)
        {
            Name = name;
            Settings = settings;
            Command = command;
            Args = args;
        }

        public void Run()
        {
            result = PluginContext.Invoke(Name, Settings, Command, Args);
        }
    }
}
