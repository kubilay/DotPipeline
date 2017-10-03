using System;

namespace DotPipeline.Plugin
{
    [System.AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
    public sealed class PluginPublishesAttribute : Attribute
    {
        readonly string fileName;
        
        public PluginPublishesAttribute(string fileName)
        {
            this.fileName = fileName;
        }

        public string FileName { get => fileName; }
    }
}