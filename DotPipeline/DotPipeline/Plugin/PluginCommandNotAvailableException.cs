using System;
using System.Runtime.Serialization;

namespace DotPipeline.Plugin
{
    [Serializable]
    internal class PluginCommandNotAvailableException : Exception
    {
        public PluginCommandNotAvailableException()
        {
        }

        public PluginCommandNotAvailableException(string message) : base(message)
        {
        }

        public PluginCommandNotAvailableException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PluginCommandNotAvailableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}