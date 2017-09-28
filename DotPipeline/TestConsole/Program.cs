using DotPipeline;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Job job = new Job();
            job.Add(new SimpleAction(() => { return true; }));
            job.Add(new WinCmdAction("exit /b 0"));
            bool retVal = job.Process();
        }
    }
}
