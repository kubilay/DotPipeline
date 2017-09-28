using DotPipeline.Runners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotPipeline
{
    public class WinCmdAction : IAction
    {
        bool result;
        string _command;
        public bool Result { get => result; private set => result = value; }
        public string Command { get => _command; private set => _command = value; }

        public WinCmdAction(string command)
        {
            Command = command;
        }

        public void Run()
        {
            int exitCode = WinCmdExecutor.Execute(Command);
            Result = (exitCode == 0);
        }
    }
}
