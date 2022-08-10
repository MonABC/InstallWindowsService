using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallWindowsService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InstallWindowsService();
            //UninstallWindowsService();
            //SetRecoveryOptions("ServiceName01090822");
        }

        public static void InstallWindowsService()
        {
            Process process = new Process();
            process.StartInfo.FileName = "InstallUtil.exe";
            process.StartInfo.WorkingDirectory = @"C:\windows\microsoft.net\framework\v4.0.30319";
            process.StartInfo.Arguments = "D:\\Service\\WindowsService01090822\\WindowsService01090822\\bin\\Debug\\WindowsService01090822.exe";
            process.StartInfo.Verb = "runas";
            process.Start();
            process.WaitForExit(60000);
        }
        public static void UninstallWindowsService()
        {
            Process process = new Process();
            process.StartInfo.FileName = "InstallUtil.exe";
            process.StartInfo.WorkingDirectory = @"C:\windows\microsoft.net\framework\v4.0.30319";
            process.StartInfo.Arguments = " -u D:\\Service\\WindowsService01090822\\WindowsService01090822\\bin\\Debug\\WindowsService01090822.exe";
            //process.StartInfo.Verb = "runas";
            process.Start();
            process.WaitForExit(60000);
        }

        static void SetRecoveryOptions(string serviceName)
        {
         
            int exitCode;
            using (var process = new Process())
            {
                var startInfo = process.StartInfo;
                startInfo.FileName = "sc";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;

                // tell Windows that the service should restart if it fails
                startInfo.Arguments = string.Format("failure \"{0}\" reset= 0 actions= restart/120000/run//run/", serviceName);
                process.Start();
                process.WaitForExit();

                exitCode = process.ExitCode;
            }

            //if (exitCode != 0)
            //    throw new InvalidOperationException();
        }




    }
}
