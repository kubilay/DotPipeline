using System;
using System.Runtime.Serialization;

namespace DotPipeline.Plugin
{
    [Serializable]
    internal class PluginNotRegisteredException : Exception
    {
        public PluginNotRegisteredException()
        {
        }

        public PluginNotRegisteredException(string message) : base(message)
        {
        }

        public PluginNotRegisteredException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PluginNotRegisteredException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}