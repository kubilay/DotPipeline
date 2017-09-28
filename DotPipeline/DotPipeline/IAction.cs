namespace DotPipeline
{
    public delegate bool ActionDelegate();

    public interface IAction
    {
        bool Result { get; }
        void Run();
    }
}
