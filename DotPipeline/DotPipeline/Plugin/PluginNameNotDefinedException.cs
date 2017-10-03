using System;
using System.Runtime.Serialization;

namespace DotPipeline.Plugin
{
    [Serializable]
    internal class PluginNameNotDefinedException : Exception
    {
        public PluginNameNotDefinedException()
        {
        }

        public PluginNameNotDefinedException(string message) : base(message)
        {
        }

        public PluginNameNotDefinedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PluginNameNotDefinedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}