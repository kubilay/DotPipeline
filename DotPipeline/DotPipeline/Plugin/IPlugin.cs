namespace DotPipeline.Plugin
{
    public interface IPlugin
    {
        string Name { get; }

        void Initialize(Settings settings);
    }
}
