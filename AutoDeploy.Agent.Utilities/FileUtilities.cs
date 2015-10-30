using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AutoDeploy.Agent.Utilities
{
    public class FileUtilities : IFileUtilities
    {
        public void CopyFile(string i_Source, string i_Dest)
        {

            if (Directory.Exists(i_Source))
            {
                if (!Directory.Exists(i_Dest))
                {
                    Directory.CreateDirectory(i_Dest);
                }
                File.Copy(i_Source, i_Dest, true);
            }
            else
            {
                throw new Exception("File : " + i_Source + " Doesnt exists");
            }

        }
        public string GetVersion(string i_Path)
        {
            if (File.Exists(i_Path))
            {
                return FileVersionInfo.GetVersionInfo(i_Path).ProductVersion;
            }
            else
            {
                return string.Empty;
            }
        }

    }

}
