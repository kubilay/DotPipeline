using System;
using System.Diagnostics;

namespace DotPipeline.Executors
{
    static class WinCmdExecutor
    {
        internal static int Execute(
            string commandToExecute,
            string workingDirectory = null,
            DataReceivedEventHandler outputDataReceived = null,
            DataReceivedEventHandler errorDataReceived = null)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c " + commandToExecute,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                WorkingDirectory = workingDirectory ?? Environment.CurrentDirectory
            };

            Process proc = new Process
            {
                StartInfo = startInfo,
                EnableRaisingEvents = true
            };

            if (outputDataReceived != null)
                proc.OutputDataReceived += outputDataReceived;
            if (errorDataReceived != null)
                proc.ErrorDataReceived += errorDataReceived;

            proc.Start();
            proc.BeginOutputReadLine();
            proc.WaitForExit();
            return proc.ExitCode;
        }

        private static void Proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Debug.WriteLine("Output : " + e.Data);
        }

        private static void Proc_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Debug.WriteLine("Error  : " + e.Data);
        }
    }
}
