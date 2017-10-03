namespace DotPipeline.Plugin
{
    [System.AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    sealed class PluginAttribute : System.Attribute
    {
        readonly string name;

        // This is a positional argument
        public PluginAttribute(string name)
        {
            this.name = name;
        }

        public string Name => name;
    }
}