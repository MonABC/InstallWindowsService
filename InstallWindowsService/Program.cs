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
            process.StartInfo.Verb = "runas";
            process.Start();
            process.WaitForExit(60000);
        }




    }
}
