using DotPipeline;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IAction job = new Job
            {
                new SimpleAction(() => { return true; }),
                new WinCmdAction("exit /b 0")
            };
            job.Run();
        }
    }
}
