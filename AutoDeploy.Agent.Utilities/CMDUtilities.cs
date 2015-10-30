using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AutoDeploy.Agent.Utilities
{
   public class CMDUtilities : ICMDUtilities
    {
       public void ExecuteCmdCommand(params string[] i_Commands)
       {
           Process p = new Process();
           ProcessStartInfo info = new ProcessStartInfo();
           info.FileName = "cmd.exe";
           info.RedirectStandardInput = true;
           info.UseShellExecute = false;
           info.CreateNoWindow = true;
           p.StartInfo = info;
           p.Start();
           using (StreamWriter sw = p.StandardInput)
           {
               foreach (string cmd in i_Commands)
               {
                   if (sw.BaseStream.CanWrite)
                   {
                       sw.WriteLine(cmd);

                   }
               }
           }
       }

    }
}
