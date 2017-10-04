using System;
using System.Runtime.Serialization;

namespace DotPipeline.Plugin
{
    [Serializable]
    internal class PluginCommandArgumentException : Exception
    {
        public PluginCommandArgumentException()
        {
        }

        public PluginCommandArgumentException(string message) : base(message)
        {
        }

        public PluginCommandArgumentException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PluginCommandArgumentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}